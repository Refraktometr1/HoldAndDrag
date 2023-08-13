using System;
using Codebase.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Projectile
{
    public class TrajectoryRenderer : MonoBehaviour 
    {
        public GameObject StartPoint;
        public GameObject OffsetPoint;
        public GameObject EndPoint;

        private LineRenderer _trajectoryLineRenderer;
        private BezierCurve _bezierCurve;
        
        private const int TrajectoryPointCount = 20;
        

        [Inject]
        public void Construct(BezierCurve bezierCurve)
        {
            _bezierCurve = bezierCurve;
        }

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
                points[i] = _bezierCurve.GetPoint(StartPoint.transform.position, OffsetPoint.transform.position, EndPoint.transform.position, extrapolationCoefficient);
            }
            
            _trajectoryLineRenderer.SetPositions(points);
        }
    }
}