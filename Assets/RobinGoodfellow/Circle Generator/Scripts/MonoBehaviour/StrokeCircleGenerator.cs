using UnityEngine;

namespace RobinGoodfellow.CircleGenerator {
    public class StrokeCircleGenerator : CircleGenerator {

        [SerializeField]
        StrokeData _strokeData;
        public StrokeData StrokeData {
            get { return (StrokeData)_strokeData.Clone(); }
            set { _strokeData = value; }
        }

        protected override void InitialiseData() {
            base.InitialiseData();
            if (_strokeData == null) {
                _strokeData = new StrokeData(0.1f, false);
            }
        }

        protected override void SetCircleState() {
            base.SetCircleState();
            Circle.Accept(new CircleStrokeVisitor(StrokeData));
        }

        protected override CircleTemplate GetCircle() {
            return new StrokeCircle(Mesh, CircleData);
        }

        public override void Accept(ICircleGeneratorVisitor circleGeneratorVisitor) {
            circleGeneratorVisitor.VisitStrokeCircleGenerator(this);
        }
    }
}