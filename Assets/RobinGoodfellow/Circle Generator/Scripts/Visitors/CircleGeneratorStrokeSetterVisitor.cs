namespace RobinGoodfellow.CircleGenerator {
    public class CircleGeneratorStrokeSetterVisitor : ICircleGeneratorVisitor {
        StrokeData _strokeData;

        public CircleGeneratorStrokeSetterVisitor(StrokeData strokeData) {
            _strokeData = strokeData;
        }

        public void VisitDashCircleGenerator(DashCircleGenerator circleGenerator) {
            circleGenerator.StrokeData = _strokeData;
        }

        public void VisitFillCircleGenerator(FillCircleGenerator circleGenerator) {
        }

        public void VisitStrokeCircleGenerator(StrokeCircleGenerator circleGenerator) {
            circleGenerator.StrokeData = _strokeData;
        }
    }
}
