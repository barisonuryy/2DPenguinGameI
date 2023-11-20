using System.Collections;
using NUnit.Framework;
using UnityEngine;
using RobinGoodfellow.CircleGenerator;
using System;



public class CircleDataTest {
    Mesh _mesh;

    [TestCaseSource(typeof(CircleDataTestData), nameof(CircleDataTestData.ArgumentExceptionTestCase))]
    public void TestArgLimitException(float radius, float completion, float angle, int polygons) {
        Assert.Throws<ArgumentOutOfRangeException>(delegate {
            CircleData CD = new CircleData(radius, completion, angle, polygons, true);
        });
    }
}

public class CircleDataTestData {
    public static IEnumerable ArgumentExceptionTestCase {
        get {
            // below min limits
            yield return new TestCaseData(-1, 0, 0, 30);
            yield return new TestCaseData(0, -1, 0, 30);
            yield return new TestCaseData(0, 0, -1, 30);
            yield return new TestCaseData(0, 0, 0, 2);

            // above max limits
            yield return new TestCaseData(0, 361, 0, 30);
            yield return new TestCaseData(0, 0, 361, 30);
            yield return new TestCaseData(0, 0, 0, 361);

        }
    }
}


