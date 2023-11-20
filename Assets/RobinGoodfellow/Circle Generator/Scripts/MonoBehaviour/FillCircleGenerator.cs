namespace RobinGoodfellow.CircleGenerator {
    public class FillCircleGenerator : CircleGenerator {
        protected override CircleTemplate GetCircle() {
            return new FillCircle(Mesh, CircleData);
        }
        public override void Accept(ICircleGeneratorVisitor circleGeneratorVisitor) {
            circleGeneratorVisitor.VisitFillCircleGenerator(this);
        }
    }
}