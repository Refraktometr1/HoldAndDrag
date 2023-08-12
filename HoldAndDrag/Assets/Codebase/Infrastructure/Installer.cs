using Codebase.Factory;
using Codebase.Infrastructure.States;
using Unity.VisualScripting;
using Zenject;

namespace Codebase.Infrastructure
{
    public class Installer : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<GameFactory>().AsSingle();
        }
    }
}