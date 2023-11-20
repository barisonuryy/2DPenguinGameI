#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
namespace RobinGoodfellow.CircleGenerator {
    public class StrokeCircleGeneratorMenu {
        [MenuItem("GameObject/2D Object/Circle Generator/Stroke Circle Generator", false, 1000)]
        static void CreateCustomGameObject(MenuCommand menuCommand) {
            GameObject go = new GameObject("Stroke Circle Generator");
            go.AddComponent<StrokeCircleGenerator>();
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}
#endif
