using System.Collections;
using NUnit.Framework;
using UnityEngine;
using RobinGoodfellow.CircleGenerator;

public class FillCircleTest {

    CircleTemplate _circle;
    Mesh _mesh = new Mesh();


    [TestCaseSource(typeof(FillCircleTestData), nameof(FillCircleTestData.VertexPositions))]
    public Vector3[] TestVertexPositions(CircleData CD, StrokeData SD) {
        _circle = new FillCircle(_mesh, CD);
        // For coverage purposes, pass stroke data, even though we don't use it.
        _circle.Accept(new CircleStrokeVisitor(SD));
        _mesh = _circle.GetMesh();
        return _mesh.vertices;
    }

    [TestCaseSource(typeof(FillCircleTestData), nameof(FillCircleTestData.Triangles))]
    public int[] TestTriangles(CircleData CD, StrokeData SD) {
        _circle = new FillCircle(_mesh, CD);
        // For coverage purposes, pass stroke data, even though we don't use it.
        _circle.Accept(new CircleStrokeVisitor(SD));
        _mesh = _circle.GetMesh();
        return _mesh.triangles;
    }
}

public class FillCircleTestData {
    static readonly int iterations = 1000;

    static CircleData CD;
    static StrokeData SD;

    static void SetupData() {
        CD = new CircleData(
            Random.Range(0.1f, 1),
            Random.Range(0, 361),
            Random.Range(0, 361),
            Random.Range(3, 361),
            Random.Range(0, 2) != 0
            );

        SD = new StrokeData(Random.Range(0.1f, 1), Random.Range(0, 2) != 0);
    }

    public static IEnumerable VertexPositions {
        get {
            Random.InitState(1234);
            for (int i = 0; i < iterations; i++) {
                SetupData();
                Vector3[] expected = GetVertexPositions();
                yield return new TestCaseData(CD, SD).Returns(expected);
            }
        }
    }

    public static IEnumerable Triangles {
        get {
            Random.InitState(1234);
            for (int i = 0; i < iterations; i++) {
                SetupData();
                int[] expected = GetTriangles();
                yield return new TestCaseData(CD, SD).Returns(expected);
            }
        }
    }


    static Vector3[] GetVertexPositions() {
        float angleReal = -CD.Angle + 90;
        Vector3[] vertices = new Vector3[0];
        if (CD.Completion > 0) {
            vertices = new Vector3[CD.PolygonQuantity + 2];
            for (int i = 0; i <= CD.PolygonQuantity; i++) {
                float rad = i * -(CD.Completion / CD.PolygonQuantity) * Mathf.Deg2Rad + (angleReal * Mathf.Deg2Rad);
                vertices[0] = new Vector2(0, 0);
                vertices[i + 1] = new Vector2(
                    Mathf.Cos(rad) * CD.Radius,
                    Mathf.Sin(rad) * CD.Radius
                );
            }
        }
        return vertices;
    }

    static int[] GetTriangles() {
        int triangleIncrement = 3;
        int[] triangles = new int[0];
        if (CD.Completion > 0) {
            triangles = new int[CD.PolygonQuantity * triangleIncrement];
            for (int ti = 0, vi = 0, x = 0; x < CD.PolygonQuantity; x++, ti += triangleIncrement, vi += 1) {
                triangles[ti] = 0;
                triangles[ti + 1] = vi + 1;
                triangles[ti + 2] = vi + 2;
            }
        }
        return triangles;
    }
}

