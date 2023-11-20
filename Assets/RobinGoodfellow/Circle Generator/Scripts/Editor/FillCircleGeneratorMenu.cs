#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
namespace RobinGoodfellow.CircleGenerator {
    public class FillCircleGeneratorMenu {
        [MenuItem("GameObject/2D Object/Circle Generator/Fill Circle Generator", false, 1000)]
        static void CreateCustomGameObject(MenuCommand menuCommand) {
            GameObject go = new GameObject("Fill Circle Generator");
            go.AddComponent<FillCircleGenerator>();
            GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
        }
    }
}
#endif