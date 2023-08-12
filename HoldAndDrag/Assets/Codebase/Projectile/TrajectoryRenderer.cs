using System;
using UnityEngine;

namespace Codebase.Projectile
{
    public class TrajectoryRenderer : MonoBehaviour 
    {
        public GameObject StartPoint;
        public GameObject OffsetPoint;
        public GameObject EndPoint;

        private LineRenderer _trajectoryLineRenderer;

        private void Start()
        {
            _trajectoryLineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            ShowTrajectory();
        }


        public void ShowTrajectory()
        {
            Vector3[] points = new Vector3[20];
            _trajectoryLineRenderer.positionCount = points.Length;

            for (int i = 0; i < points.Length; i++)
            {
                points[i] = BezierCurvePoint(StartPoint.transform.position, OffsetPoint.transform.position, EndPoint.transform.position, (i+1) * 0.05f);
            }
            
            _trajectoryLineRenderer.SetPositions(points);
        }
        
        private Vector3 BezierCurvePoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            t = Mathf.Clamp01(t);
            return
                Mathf.Pow(1 - t,2) * p0 +
                2f * (1 - t)* t * p1 +
                t * t * p2;
        }
    }
}