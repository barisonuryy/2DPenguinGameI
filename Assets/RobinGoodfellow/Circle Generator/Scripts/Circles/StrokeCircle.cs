using UnityEngine;
using System.Collections.Generic;
namespace RobinGoodfellow.CircleGenerator {
    public class StrokeCircle : CircleTemplate {

        public StrokeCircle(Mesh mesh, CircleData circleData) : base(mesh, circleData) { }
        public StrokeData StrokeData { get; set; }

        float RadiusMultiplier {
            get {
                return StrokeData.KeepStrokeSizeRelative ? (1 + StrokeData.StrokeSize) * CircleData.Radius : StrokeData.StrokeSize + CircleData.Radius;
            }
        }

        protected override int VertexIndexIncrement { get { return 1; } }
        protected override int TriangleIndexIncrement { get { return 6; } }

        protected override Vector3[] CreateVerticesArray() {
            return new Vector3[(CircleData.PolygonQuantity + 1) * 2];
        }

        protected override List<IndexValue> DeriveTriangleIndices(int triangleIndex, int vertexIndex) {
            int ti = triangleIndex;
            int vi = vertexIndex;

            List<IndexValue> list = new List<IndexValue>();
            list.Add(new IndexValue(ti, vi));
            list.Add(new IndexValue(ti + 1, vi + 1));
            list.Add(new IndexValue(ti + 4, vi + 1));
            list.Add(new IndexValue(ti + 2, vi + CircleData.PolygonQuantity + 1));
            list.Add(new IndexValue(ti + 3, vi + CircleData.PolygonQuantity + 1));
            list.Add(new IndexValue(ti + 5, vi + CircleData.PolygonQuantity + 2));
            return list;
        }

        protected override Vector2 DeriveInnerVertexPositionFromRad(float radian) {
            float x = Mathf.Cos(radian) * CircleData.Radius;
            float y = Mathf.Sin(radian) * CircleData.Radius;
            return new Vector2(x, y);
        }

        protected override Vector2 DeriveOuterVertexPositionFromRad(float radian) {
            float x = Mathf.Cos(radian) * RadiusMultiplier;
            float y = Mathf.Sin(radian) * RadiusMultiplier;
            return new Vector2(x, y);
        }

        protected override int DeriveInnerVertexIndex(int index) {
            return index + CircleData.PolygonQuantity + 1;
        }

        protected override int DeriveOuterVertexIndex(int index) {
            return index;
        }

        public override void Accept(ICircleVisitor visitor) {
            visitor.VisitStrokeCircle(this);
        }
    }
}
