namespace RobinGoodfellow.CircleGenerator {
    public class CircleGeneratorStrokeGetterVisitor : ICircleGeneratorVisitor {
        public StrokeData StrokeData { get; set; }

        public void VisitDashCircleGenerator(DashCircleGenerator circleGenerator) {
            StrokeData = circleGenerator.StrokeData;
        }

        public void VisitFillCircleGenerator(FillCircleGenerator circleGenerator) {
        }

        public void VisitStrokeCircleGenerator(StrokeCircleGenerator circleGenerator) {
            StrokeData = circleGenerator.StrokeData;
        }
    }
}
