using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using RobinGoodfellow.CircleGenerator;
public class DashCircleGeneratorTest : PlaymodeTest {
    [UnityTest]
    public IEnumerator TestDashCircleGeneratorControl() {
        _circleGO = new GameObject("Dash Circle");
        DashCircleGenerator circle = _circleGO.AddComponent<DashCircleGenerator>();
        yield return new WaitForSeconds(1);
        CircleData cd = circle.CircleData;
        MeshFilter mf = _circleGO.GetComponent<MeshFilter>();
        Vector3[] oldVertices = mf.sharedMesh.vertices;
        cd.Radius += 0;
        circle.CircleData = cd;
        circle.Generate();
        yield return new WaitForSeconds(1);
        Vector3[] newVertices = mf.sharedMesh.vertices;
        Assert.AreEqual(cd.Radius, circle.CircleData.Radius);
        Assert.AreEqual(oldVertices[1], newVertices[1]);
        yield return new WaitForSeconds(1);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestDashCircleGeneratorMeshUpdate() {
        _circleGO = new GameObject("Dash Circle");
        DashCircleGenerator circle = _circleGO.AddComponent<DashCircleGenerator>();
        yield return new WaitForSeconds(1);
        CircleData cd = circle.CircleData;
        MeshFilter mf = _circleGO.GetComponent<MeshFilter>();
        Vector3[] oldVertices = mf.sharedMesh.vertices;
        cd.Radius += 5;
        circle.CircleData = cd;
        circle.Generate();
        yield return new WaitForSeconds(1);
        Vector3[] newVertices = mf.sharedMesh.vertices;
        Assert.AreEqual(cd.Radius, circle.CircleData.Radius);
        Assert.AreNotEqual(oldVertices[1], newVertices[1]);
        yield return new WaitForSeconds(1);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestDashCircleGeneratorMeshUpdateWithVisitor() {
        _circleGO = new GameObject("Dash Circle");
        CircleGenerator circle = _circleGO.AddComponent<DashCircleGenerator>();
        yield return new WaitForSeconds(1);
        CircleGeneratorStrokeGetterVisitor getterVisitor = new CircleGeneratorStrokeGetterVisitor();
        circle.Accept(getterVisitor);
        StrokeData sd = getterVisitor.StrokeData;
        MeshFilter mf = _circleGO.GetComponent<MeshFilter>();
        Vector3[] oldVertices = mf.sharedMesh.vertices;
        sd.StrokeSize += 3;
        circle.Accept(new CircleGeneratorStrokeSetterVisitor(sd));
        circle.Generate();
        yield return new WaitForSeconds(1);
        Vector3[] newVertices = mf.sharedMesh.vertices;
        Assert.AreNotEqual(oldVertices[1], newVertices[1]);
        yield return new WaitForSeconds(1);
        yield return null;
    }
}
