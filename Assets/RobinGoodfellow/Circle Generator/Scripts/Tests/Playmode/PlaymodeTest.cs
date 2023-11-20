using NUnit.Framework;
using UnityEngine;

public abstract class PlaymodeTest {
    protected GameObject _circleGO;
    protected GameObject _camGO;
    [SetUp]
    public void MakeCamera() {

        _camGO = GameObject.Find("Cam");
        if (_camGO == null) {
            _camGO = new GameObject("Cam");
            Camera cam = _camGO.AddComponent<Camera>();
            Transform t = cam.transform;
            Vector3 p = t.position;
            p.z = -10;
            t.position = p;
        }



    }
    [TearDown]
    public void TearDown() {
        if (_circleGO != null) {
            GameObject.Destroy(_circleGO);
        }
    }

}