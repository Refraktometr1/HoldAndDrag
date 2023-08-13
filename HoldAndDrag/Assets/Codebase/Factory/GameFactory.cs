using System.Collections.Generic;
using System.Linq;
using Codebase.Projectile;
using Codebase.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Codebase.Factory
{
    public class GameFactory
    {
        public List<ProjectileMove> CardsMovers = new List<ProjectileMove>();
        
        private BezierCurve _bezierCurve;
        private GameObject _target;
        private CardsService _cardsService;

        [Inject]
        public void Construct(BezierCurve bezierCurve, CardsService cardsService)
        {
            _bezierCurve = bezierCurve;
            _cardsService = cardsService;
        }

        public GameObject CreateCard()
        {
            GameObject cardGameObject = Object.Instantiate(Resources.Load<GameObject>("Card"));
            
            GameObject offsetPoint = Object.Instantiate(Resources.Load<GameObject>("OffsetPoint"));
            offsetPoint.transform.position = Vector3.Lerp(_target.transform.position, cardGameObject.transform.position, 0.5f);

            var projectileMove = cardGameObject.GetComponent<ProjectileMove>();
            projectileMove.OffsetPoint = offsetPoint;
            projectileMove.BezierCurve = _bezierCurve;
            CardsMovers.Add(projectileMove);
            
            GameObject trajectoryRendererGameObject = Object.Instantiate(Resources.Load<GameObject>("TrajectoryRenderer"));
            var trajectoryRenderer = trajectoryRendererGameObject.GetComponent<TrajectoryRenderer>();
            trajectoryRenderer.EndPoint = _target;
            trajectoryRenderer.OffsetPoint = offsetPoint;
            trajectoryRenderer.StartPoint = cardGameObject;
            trajectoryRenderer.BezierCurve = _bezierCurve;
            
            var projectileShooter = cardGameObject.GetComponent<ProjectileShooter>();
            projectileShooter.OffsetPoint = offsetPoint;
            projectileShooter.Target = _target;
            projectileShooter.TrajectoryRendererGameObject = trajectoryRendererGameObject;
            
            return cardGameObject;
        }

        public GameObject CreateTarget()
        {
            _target = Object.Instantiate(Resources.Load<GameObject>("Target"));
            return _target;
        }

        public void CreateObstacles(GameObject card, GameObject target)
        {
            GameObject obstacleGameObject = Object.Instantiate(Resources.Load<GameObject>("Obstacle"));
            obstacleGameObject.transform.position = Vector3.Lerp(card.transform.position, target.transform.position, 0.4f); 
            
            GameObject obstacleGameObject1 = Object.Instantiate(Resources.Load<GameObject>("Obstacle"));
            obstacleGameObject1.transform.position = Vector3.Lerp(card.transform.position, target.transform.position, 0.6f); 
            
            GameObject obstacleGameObject2 = Object.Instantiate(Resources.Load<GameObject>("Obstacle"));
            obstacleGameObject2.transform.position = Vector3.Lerp(card.transform.position, target.transform.position, 0.5f) + Vector3.left*2; 
        }
        
        public GameObject CreateMainCanvas() => Object.Instantiate(Resources.Load<GameObject>("UI/Canvas"));

        public void CreateNewCardButton(Transform parent)
        {
            var cardGameObject = Object.Instantiate(Resources.Load<GameObject>("UI/NewCard"), parent);
            var cardButton = cardGameObject.GetComponent<Button>();
            cardButton.onClick.AddListener(()=> _cardsService.CreateNewCard());
        }
    }
}