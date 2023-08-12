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