using Codebase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Codebase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;
        
        [Inject]
        public void Construct(GameStateMachine stateMachine, LoadLevelState loadLevelState, GameLoopState gameLoopState)
        {
            _stateMachine = stateMachine;
            _stateMachine.AddState(typeof(LoadLevelState), loadLevelState);
            _stateMachine.AddState(typeof(GameLoopState), gameLoopState);
        }

        private void Awake()
        {
            _stateMachine.Enter<LoadLevelState, string>("Main");
        }
    }
}