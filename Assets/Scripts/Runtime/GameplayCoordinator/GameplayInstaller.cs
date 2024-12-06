using Runtime.GameplayCoordinator.GameplayStates;
using Zenject;

namespace Runtime.GameplayCoordinator
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameplayStates();
            BindGameplayCoordinator();
        }

        private void BindGameplayStates()
        {
            Container.Bind<InitializeMatchState>().AsSingle();
            Container.Bind<FinalizeMatchState>().AsSingle();

            Container.Bind<StartRoundState>().AsSingle();
            Container.Bind<EndRoundState>().AsSingle();
        }
        
        private void BindGameplayCoordinator()
        {
            Container
                .Bind<IGameplayCoordinator>()
                .To<LocalGameplayCoordinator>()
                .AsSingle();
        }
    }
}