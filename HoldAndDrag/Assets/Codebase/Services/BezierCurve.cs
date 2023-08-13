using UnityEngine;

namespace Codebase.Services
{
    public class BezierCurve
    {
        public Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            t = Mathf.Clamp01(t);
            return
                Mathf.Pow(1 - t,2) * p0 +
                2f * (1 - t)* t * p1 +
                t * t * p2;
        }
    }
}