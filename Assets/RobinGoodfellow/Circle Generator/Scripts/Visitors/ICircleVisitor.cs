namespace RobinGoodfellow.CircleGenerator {
    public interface ICircleVisitor {
        public void VisitStrokeCircle(StrokeCircle circle);
        public void VisitDashCircle(DashCircle circle);
        public void VisitFillCircle(FillCircle circle);
    }
}
