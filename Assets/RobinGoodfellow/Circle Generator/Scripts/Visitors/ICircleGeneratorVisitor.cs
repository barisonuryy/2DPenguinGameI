namespace RobinGoodfellow.CircleGenerator {
    public interface ICircleGeneratorVisitor {

        public void VisitStrokeCircleGenerator(StrokeCircleGenerator circleGenerator);
        public void VisitDashCircleGenerator(DashCircleGenerator circleGenerator);
        public void VisitFillCircleGenerator(FillCircleGenerator circleGenerator);
    }
}
