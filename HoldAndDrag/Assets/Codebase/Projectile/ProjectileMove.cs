using System.Collections;
using Codebase.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Projectile
{
    public class ProjectileMove : MonoBehaviour
    {
        [SerializeField] private GameObject _offsetPoint;
        
        private float _elapsedTime;
        private BezierCurve _bezierCurve;

        [Inject]
        public void Construct(BezierCurve bezierCurve)
        {
            _bezierCurve = bezierCurve;
        }


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
            
                movedGameObject.transform.position = _bezierCurve.GetPoint
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
    }
}