using UnityEngine;
using System.Collections.Generic;
namespace RobinGoodfellow.CircleGenerator {
    public abstract class CircleTemplate {
        protected struct IndexValue {
            public IndexValue(int index, int value) {
                Index = index;
                Value = value;
            }
            public int Index;
            public int Value;
        }

        protected abstract int VertexIndexIncrement { get; }
        protected abstract int TriangleIndexIncrement { get; }
        protected abstract Vector3[] CreateVerticesArray();
        protected abstract List<IndexValue> DeriveTriangleIndices(int triangleIndex, int vertexIndex);
        protected abstract Vector2 DeriveInnerVertexPositionFromRad(float radian);
        protected abstract Vector2 DeriveOuterVertexPositionFromRad(float radian);
        protected abstract int DeriveInnerVertexIndex(int index);
        protected abstract int DeriveOuterVertexIndex(int index);
        public abstract void Accept(ICircleVisitor visitor);

        public CircleTemplate(Mesh mesh, CircleData circleData) {
            Mesh = mesh;
            CircleData = circleData;
        }

        public CircleData CircleData { get; set; }
        protected float RealAngle { get { return -CircleData.Angle + 90; } }
        protected Mesh Mesh;
        Vector3[] Vertices;
        int[] Triangles;

        public Mesh GetMesh() {
            Mesh.Clear();

            if (CircleData.Completion == 0) {
                return Mesh;
            }

            Vertices = CreateVerticesArray();
            SetMeshVertices();
            Mesh.RecalculateNormals();
            SetMeshTriangles();

            return Mesh;
        }


        void SetMeshVertices() {
            for (int i = 0; i <= CircleData.PolygonQuantity; i++) {
                float rad = GetRadianForPolygon(i);
                Vertices[DeriveOuterVertexIndex(i)] = DeriveOuterVertexPositionFromRad(rad);
                Vertices[DeriveInnerVertexIndex(i)] = DeriveInnerVertexPositionFromRad(rad);
            }
            Mesh.vertices = Vertices;
        }

        float GetRadianForPolygon(int index) {
            return index * -(CircleData.Completion / CircleData.PolygonQuantity) * Mathf.Deg2Rad + (RealAngle * Mathf.Deg2Rad);
        }

        void SetMeshTriangles() {
            Triangles = new int[CircleData.PolygonQuantity * TriangleIndexIncrement];
            for (int ti = 0, vi = 0, x = 0; x < CircleData.PolygonQuantity; x++, ti += TriangleIndexIncrement, vi += VertexIndexIncrement) {
                SetTriangleIndicesFromListIndexValueList(DeriveTriangleIndices(ti, vi));
            }
            Mesh.triangles = Triangles;
        }

        void SetTriangleIndicesFromListIndexValueList(List<IndexValue> list) {
            foreach (var item in list) {
                Triangles[item.Index] = item.Value;
            }
        }

    }
}