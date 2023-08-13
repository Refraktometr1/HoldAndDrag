using Codebase.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Codebase.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private AsyncOperation _loadScene;
        
        private readonly GameStateMachine _stateMachine;
        private readonly GameFactory _gameFactory;


        [Inject]
        public LoadLevelState(GameStateMachine gameStateMachine, GameFactory gameFactory)
        {
            _stateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _loadScene =  SceneManager.LoadSceneAsync(sceneName);
            _loadScene.completed += OnLoaded;
        }

        private void OnLoaded(AsyncOperation obj)
        {
            var target = _gameFactory.CreateTarget();
            var card = _gameFactory.CreateCard();
            
            _gameFactory.CreateObstacles(card, target);

            var canvas = _gameFactory.CreateMainCanvas();
            _gameFactory.CreateNewCardButton(canvas.transform);
        }

        public void Enter()
        {
        }

        public void Exit()
        {
            _loadScene.completed -= OnLoaded;
        }
    }
}