#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
namespace RobinGoodfellow.CircleGenerator {
    public class DashCircleGeneratorMenu {
        [MenuItem("GameObject/2D Object/Circle Generator/Dash Circle Generator", false, 1000)]
        static void CreateCustomGameObject(MenuCommand menuCommand) {
            GameObject go = new GameObject("Dash Circle Generator");
            go.AddComponent<DashCircleGenerator>();
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}
#endif