using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using RobinGoodfellow.CircleGenerator;
public class FillCircleGeneratorTest : PlaymodeTest {

    [UnityTest]
    public IEnumerator TestFillCircleGeneratorControl() {
        _circleGO = new GameObject("Fill Circle");
        FillCircleGenerator circle = _circleGO.AddComponent<FillCircleGenerator>();
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
    public IEnumerator TestFillCircleGeneratorMeshUpdate() {
        _circleGO = new GameObject("Fill Circle");
        FillCircleGenerator circle = _circleGO.AddComponent<FillCircleGenerator>();
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
    public IEnumerator TestFillCircleGeneratorWithStrokeVisitor() {
        _circleGO = new GameObject("Fill Circle");
        CircleGenerator circle = _circleGO.AddComponent<FillCircleGenerator>();
        yield return new WaitForSeconds(1);
        CircleGeneratorStrokeGetterVisitor getterVisitor = new CircleGeneratorStrokeGetterVisitor();
        circle.Accept(getterVisitor);
        StrokeData sd = getterVisitor.StrokeData;
        MeshFilter mf = _circleGO.GetComponent<MeshFilter>();
        Vector3[] oldVertices = mf.sharedMesh.vertices;
        Assert.IsNull(sd);
        circle.Accept(new CircleGeneratorStrokeSetterVisitor(sd));
        circle.Generate();
        yield return new WaitForSeconds(1);
        Vector3[] newVertices = mf.sharedMesh.vertices;
        Assert.AreEqual(oldVertices[1], newVertices[1]);
        yield return new WaitForSeconds(1);
        yield return null;
    }
}
