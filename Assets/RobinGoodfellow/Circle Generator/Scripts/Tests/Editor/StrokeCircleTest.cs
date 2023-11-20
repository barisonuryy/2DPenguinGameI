using System.Collections;
using NUnit.Framework;
using UnityEngine;
using RobinGoodfellow.CircleGenerator;

public class StrokeCircleTest {

    CircleTemplate _circle;
    Mesh _mesh = new Mesh();

    [TestCaseSource(typeof(StrokeCircleTestData), nameof(StrokeCircleTestData.VertexPositions))]
    public Vector3[] TestVertexPositions(CircleData CD, StrokeData SD) {

        _circle = new StrokeCircle(_mesh, CD);
        _circle.Accept(new CircleStrokeVisitor(SD));
        _mesh = _circle.GetMesh();
        return _mesh.vertices;
    }

    [TestCaseSource(typeof(StrokeCircleTestData), nameof(StrokeCircleTestData.Triangles))]
    public int[] TestTriangles(CircleData CD, StrokeData SD) {
        _circle = new StrokeCircle(_mesh, CD);
        _circle.Accept(new CircleStrokeVisitor(SD));
        _mesh = _circle.GetMesh();
        return _mesh.triangles;
    }
}

public class StrokeCircleTestData {
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



    static float GetRadiusMultiplier() {
        return SD.KeepStrokeSizeRelative ? (1 + SD.StrokeSize) * CD.Radius : SD.StrokeSize + CD.Radius;
    }

    static Vector3[] GetVertexPositions() {
        float radiusMult = GetRadiusMultiplier();
        float angleReal = -CD.Angle + 90;
        Vector3[] vertices = new Vector3[0];
        if (CD.Completion > 0) {
            vertices = new Vector3[(CD.PolygonQuantity + 1) * 2];
            for (int i = 0; i <= CD.PolygonQuantity; i++) {
                float rad = i * -(CD.Completion / CD.PolygonQuantity) * Mathf.Deg2Rad + (angleReal * Mathf.Deg2Rad);
                vertices[i + CD.PolygonQuantity + 1] = new Vector2(
                    Mathf.Cos(rad) * CD.Radius,
                    Mathf.Sin(rad) * CD.Radius
                );
                vertices[i] = new Vector2(
                    Mathf.Cos(rad) * radiusMult,
                    Mathf.Sin(rad) * radiusMult
                );
            }
        }
        return vertices;
    }

    static int[] GetTriangles() {
        int triangleIncrement = 6;
        int[] triangles = new int[0];
        if (CD.Completion > 0) {
            triangles = new int[CD.PolygonQuantity * triangleIncrement];
            for (int ti = 0, vi = 0, x = 0; x < CD.PolygonQuantity; x++, ti += triangleIncrement, vi += 1) {
                triangles[ti] = vi;
                triangles[ti + 1] = triangles[ti + 4] = vi + 1;
                triangles[ti + 2] = triangles[ti + 3] = vi + CD.PolygonQuantity + 1;
                triangles[ti + 5] = vi + CD.PolygonQuantity + 2;
            }
        }
        return triangles;
    }
}

