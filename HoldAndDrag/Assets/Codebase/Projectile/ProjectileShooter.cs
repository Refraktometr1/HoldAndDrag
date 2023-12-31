﻿using UnityEngine;

namespace Codebase.Projectile
{
    public class ProjectileShooter : MonoBehaviour
    {
        public ProjectileMove ProjectileMove;
        public GameObject OffsetPoint;
        public GameObject Target;
        public GameObject TrajectoryRendererGameObject;
        public int AnimationTime = 1;
        
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private Vector3 _offset;
        private Vector3 _offsetPointPosition;

        private void Start() => _offsetPointPosition = OffsetPoint.transform.position;

        private void OnMouseDown() => _startPosition = Input.mousePosition;

        private void OnMouseDrag()
        {   
            _endPosition = Input.mousePosition;
            _offset = Vector3.Project(_endPosition - _startPosition, Vector3.right) ;
            OffsetPoint.transform.position = _offsetPointPosition + _offset * 0.03f;
        }

        private void OnMouseUp()
        {
            ProjectileMove.MoveGameObject(this.gameObject, Target, AnimationTime);
            Destroy(TrajectoryRendererGameObject);
        }
    }
}