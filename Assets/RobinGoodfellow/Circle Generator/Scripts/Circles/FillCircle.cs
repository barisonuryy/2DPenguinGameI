using UnityEngine;
using System.Collections.Generic;
namespace RobinGoodfellow.CircleGenerator {
    public class FillCircle : CircleTemplate {
        public FillCircle(Mesh mesh, CircleData circleData) : base(mesh, circleData) { }

        protected override int VertexIndexIncrement { get { return 1; } }
        protected override int TriangleIndexIncrement { get { return 3; } }

        protected override Vector3[] CreateVerticesArray() {
            return new Vector3[CircleData.PolygonQuantity + 2];
        }

        protected override List<IndexValue> DeriveTriangleIndices(int triangleIndex, int vertexIndex) {
            int ti = triangleIndex;
            int vi = vertexIndex;
            List<IndexValue> list = new List<IndexValue>();
            list.Add(new IndexValue(ti, 0));
            list.Add(new IndexValue(ti + 1, vi + 1));
            list.Add(new IndexValue(ti + 2, vi + 2));
            return list;
        }

        protected override Vector2 DeriveInnerVertexPositionFromRad(float radian) {
            return new Vector2(0, 0);
        }

        protected override Vector2 DeriveOuterVertexPositionFromRad(float radian) {
            float x = Mathf.Cos(radian) * CircleData.Radius;
            float y = Mathf.Sin(radian) * CircleData.Radius;
            return new Vector2(x, y);
        }

        protected override int DeriveInnerVertexIndex(int index) {
            return 0;
        }

        protected override int DeriveOuterVertexIndex(int index) {
            return index + 1;
        }

        public override void Accept(ICircleVisitor visitor) {
            visitor.VisitFillCircle(this);
        }
    }
}
