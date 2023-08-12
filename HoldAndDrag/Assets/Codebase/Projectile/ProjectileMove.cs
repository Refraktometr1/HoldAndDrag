using System;
using System.Collections;
using UnityEngine;

namespace Codebase.Projectile
{
    public class ProjectileMove : MonoBehaviour
    {
        [SerializeField] private GameObject _offsetPoint;
        [SerializeField] private float _animationTime = 1f;
        [SerializeField] private GameObject _target;
        
        private float _elapsedTime;

        public void MoveGameObject(GameObject gameObject, GameObject endPositionGO,  float animationTime)
        {
            StartCoroutine(AnimatorMove(gameObject, endPositionGO, animationTime));
        }
        
        private IEnumerator AnimatorMove(GameObject movedGameObject,  GameObject endPositionGO, float animationTime)
        {
            var startPosition = this.transform.position;
            
            _elapsedTime = 0;
            while (Vector3.SqrMagnitude(movedGameObject.transform.position - endPositionGO.transform.position) > 0.1f )
            {
                _elapsedTime += Time.deltaTime;
                var percentageComplete =  _elapsedTime / animationTime;
            
                movedGameObject.transform.position = BezierCurvePoint
                (startPosition,
                    _offsetPoint.transform.position,
                    endPositionGO.transform.position,
                    percentageComplete
                );
                yield return null;
            }
            movedGameObject.SetActive(false);
            _elapsedTime = 0;
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