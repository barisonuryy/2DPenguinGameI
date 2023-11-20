using UnityEngine;
using RobinGoodfellow.CircleGenerator;

public class Demo : MonoBehaviour {
    [SerializeField]
    FillCircleGenerator fillCircle;
    [SerializeField]
    CircleGenerator dashCircle;
    [SerializeField]
    StrokeCircleGenerator strokeCircle;
    CircleGeneratorStrokeGetterVisitor getterVisitor = new CircleGeneratorStrokeGetterVisitor();


    float startTime;
    float lerpTime = 5;

    bool increase = true;

    void Start() {
        startTime = Time.time;
    }

    void Update() {
        CircleData fillCircleCircleData = fillCircle.CircleData;
        fillCircleCircleData.Completion = GetDegrees();
        fillCircle.CircleData = fillCircleCircleData;
        fillCircle.Generate();

        CircleData dashCircleCircleData = dashCircle.CircleData;
        dashCircleCircleData.Angle = GetDegrees();
        dashCircle.CircleData = dashCircleCircleData;
        //For passing StrokeData, we can use the visitor pattern (Accept()) if we want to use the abstract CircleGenerator class
        dashCircle.Accept(getterVisitor);
        StrokeData dashCircleStrokeData = getterVisitor.StrokeData;
        dashCircleStrokeData.StrokeSize = GetSize();
        dashCircle.Accept(new CircleGeneratorStrokeSetterVisitor(dashCircleStrokeData));
        dashCircle.Generate();

        // Or simply reference the concrete implementation
        StrokeData strokeCircleStrokeData = strokeCircle.StrokeData;
        strokeCircleStrokeData.StrokeSize = GetSize();
        strokeCircle.StrokeData = strokeCircleStrokeData;
        strokeCircle.Generate();
    }

    float GetDegrees() {
        float interpolant = GetInterpolant();
        float degrees = Mathf.Clamp(interpolant * 360, 0, 360);
        return degrees;
    }

    float GetSize() {
        float interpolant = GetInterpolant();
        float size = Mathf.Clamp((interpolant * 0.1f) + 0.1f, 0.1f, 0.2f);
        return size;
    }

    float GetInterpolant() {
        if (Time.time - startTime > lerpTime) {
            startTime = Time.time;
            increase = !increase;
        }
        float timeDif = Time.time - startTime;
        float t = timeDif / lerpTime;
        float interpolant = ParametricBlend(t);
        if (increase == false) {
            interpolant = 1 - interpolant;
        }
        return interpolant;
    }

    float ParametricBlend(float t) {
        float alpha = 2.1f;
        float sqt = t * t;
        return sqt / (alpha * (sqt - t) + 1.0f);
    }
}
