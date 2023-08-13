﻿using Codebase.Projectile;
using Codebase.Services;
using UnityEngine;
using Zenject;

namespace Codebase.Factory
{
    public class GameFactory
    {
        private BezierCurve _bezierCurve;
        
        [Inject]
        public void Construct(BezierCurve bezierCurve)
        {
            _bezierCurve = bezierCurve;
        }


        public GameObject CreateCard(GameObject target)
        {
            GameObject cardGameObject = Object.Instantiate(Resources.Load<GameObject>("Card"));
            
            GameObject offsetPoint = Object.Instantiate(Resources.Load<GameObject>("OffsetPoint"));
            offsetPoint.transform.position = Vector3.Lerp(target.transform.position, cardGameObject.transform.position, 0.5f);

            var projectileMove = cardGameObject.GetComponent<ProjectileMove>();
            projectileMove.OffsetPoint = offsetPoint;
            projectileMove.BezierCurve = _bezierCurve;
            
            GameObject trajectoryRendererGameObject = Object.Instantiate(Resources.Load<GameObject>("TrajectoryRenderer"));
            var trajectoryRenderer = trajectoryRendererGameObject.GetComponent<TrajectoryRenderer>();
            trajectoryRenderer.EndPoint = target;
            trajectoryRenderer.OffsetPoint = offsetPoint;
            trajectoryRenderer.StartPoint = cardGameObject;
            trajectoryRenderer.BezierCurve = _bezierCurve;
            
            var projectileShooter = cardGameObject.GetComponent<ProjectileShooter>();
            projectileShooter.OffsetPoint = offsetPoint;
            projectileShooter.Target = target;
            projectileShooter.TrajectoryRendererGameObject = trajectoryRendererGameObject;

            return cardGameObject;
        }

        public GameObject CreateTarget() => Object.Instantiate(Resources.Load<GameObject>("Target"));

        public void CreateObstacles(GameObject card, GameObject target)
        {
            GameObject obstacleGameObject = Object.Instantiate(Resources.Load<GameObject>("Obstacle"));
            obstacleGameObject.transform.position = Vector3.Lerp(card.transform.position, target.transform.position, 0.4f); 
            
            GameObject obstacleGameObject1 = Object.Instantiate(Resources.Load<GameObject>("Obstacle"));
            obstacleGameObject1.transform.position = Vector3.Lerp(card.transform.position, target.transform.position, 0.6f); 
            
            GameObject obstacleGameObject2 = Object.Instantiate(Resources.Load<GameObject>("Obstacle"));
            obstacleGameObject2.transform.position = Vector3.Lerp(card.transform.position, target.transform.position, 0.5f) + Vector3.left*2; 
        }
    }
}