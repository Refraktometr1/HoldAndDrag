using Codebase.Services;
using UnityEngine;

namespace Codebase.Projectile
{
    public class TrajectoryRenderer : MonoBehaviour 
    {
        public GameObject StartPoint;
        public GameObject OffsetPoint;
        public GameObject EndPoint;
        public BezierCurve BezierCurve;

        private LineRenderer _trajectoryLineRenderer;

        private const int TrajectoryPointCount = 20;

        private void Start()
        {
            _trajectoryLineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            ShowTrajectory();
        }


        private void ShowTrajectory()
        {
            Vector3[] points = new Vector3[TrajectoryPointCount];
            _trajectoryLineRenderer.positionCount = points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                float extrapolationCoefficient = (i + 1) * (1 / (float)TrajectoryPointCount);
                points[i] = BezierCurve.GetPoint(StartPoint.transform.position, OffsetPoint.transform.position, EndPoint.transform.position, extrapolationCoefficient);
            }
            
            _trajectoryLineRenderer.SetPositions(points);
        }
    }
}