using UnityEngine;

namespace Codebase.Projectile
{
    public class ProjectileShooter : MonoBehaviour
    {
        public GameObject OffsetPoint;
        public GameObject Target;
        public ProjectileMove ProjectileMove;
        public GameObject TrajectoryRendererGameObject;
        public int AnimationTime = 1;
        
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private Vector3 _offset;
        private Vector3 _offsetPointPosition;

        private bool _isdrag;

        private void Start()
        {
            _offsetPointPosition = OffsetPoint.transform.position;
        }

        private void OnMouseDown()
        {
            _startPosition = Input.mousePosition;
        }

        private void OnMouseDrag()
        {   
            _endPosition = Input.mousePosition;

            _offset = Vector3.Project(_endPosition - _startPosition, Vector3.right) ;

            OffsetPoint.transform.position = _offsetPointPosition + _offset * 0.01f;
        }

        private void OnMouseUp()
        {
            ProjectileMove.MoveGameObject(this.gameObject, Target, AnimationTime);
            TrajectoryRendererGameObject.SetActive(false);
            _endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _isdrag = false;
        }
    }
}