using UnityEngine;

namespace RobinGoodfellow.CircleGenerator {
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer)), ExecuteAlways]
    public abstract class CircleGenerator : MonoBehaviour {
        [SerializeField]
        CircleData _circleData;
        public CircleData CircleData {
            get { return (CircleData)_circleData.Clone(); }
            set { _circleData = value; }
        }


        protected CircleTemplate Circle;
        protected Mesh Mesh;

        protected void Awake() {
            InitialiseData();
        }

        protected void Start() {
            Generate();
        }

        protected virtual void InitialiseData() {
            if (_circleData == null) {
                _circleData = new CircleData(1, 360, 0, 32, true);
            }
        }

        /// <summary>
        /// Generate the circle's mesh. Set CircleData prior to Generating.
        /// </summary>
        public void Generate() {
            CreateMesh();
            InstantiateCircle();
            SetCircleState();
            Mesh = Circle.GetMesh();
        }

        void CreateMesh() {
            if (Mesh == null) {
                Mesh = new Mesh();
                GetComponent<MeshFilter>().sharedMesh = Mesh;
                Mesh.name = "Circle";
            }
        }

        void InstantiateCircle() {
            if (Circle == null) {
                Circle = GetCircle();
            }
        }

        protected virtual void SetCircleState() {
            Circle.CircleData = _circleData;
        }

        protected abstract CircleTemplate GetCircle();

        public abstract void Accept(ICircleGeneratorVisitor circleGeneratorVisitor);


#if UNITY_EDITOR
        private void OnValidate() => UnityEditor.EditorApplication.delayCall += _OnValidate;

        private void _OnValidate() {
            UnityEditor.EditorApplication.delayCall -= _OnValidate;
            if (this == null) return;
            Generate();
        }
#endif

    }
}