namespace RobinGoodfellow.CircleGenerator {
    public class CircleStrokeVisitor : ICircleVisitor {
        StrokeData _strokeData;
        public CircleStrokeVisitor(StrokeData strokeData) {
            _strokeData = strokeData;
        }

        public void VisitDashCircle(DashCircle circle) {
            circle.StrokeData = _strokeData;
        }

        public void VisitFillCircle(FillCircle circle) {

        }

        public void VisitStrokeCircle(StrokeCircle circle) {
            circle.StrokeData = _strokeData;
        }
    }
}
