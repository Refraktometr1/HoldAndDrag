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
            Vector3[] points = new Vector3[20];
            _trajectoryLineRenderer.positionCount = points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = _bezierCurve.GetPoint(StartPoint.transform.position, OffsetPoint.transform.position, EndPoint.transform.position, (i+1) * 0.05f);
            }
            
            _trajectoryLineRenderer.SetPositions(points);
        }
    }
}