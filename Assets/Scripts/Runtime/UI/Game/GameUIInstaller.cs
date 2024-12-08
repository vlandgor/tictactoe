using Runtime.GameplayCoordinator;
using Runtime.LoadingProvider;
using Runtime.UI.Game.Models;
using Runtime.UI.Game.Presenters;
using Runtime.UI.Game.Views;
using UnityEngine;
using Zenject;

namespace Runtime.UI.Game
{
    public class GameUIInstaller : MonoInstaller
    {
        [SerializeField] private GameHudView _gameHudView;
        [SerializeField] private GameResultView _gameResultView;
        
        public override void InstallBindings()
        {
            BindMediator();
            
            BindGameHud();
            BindGameResult();
        }

        private void BindGameHud()
        {
            GameHudModel model = new GameHudModel();
            
            Container
                .Bind<GameHudPresenter>()
                .AsSingle()
                .WithArguments(model, _gameHudView);
        }
        
        private void BindGameResult()
        {
            ILoadingProvider loadingProvider = Container.Resolve<ILoadingProvider>();
            IGameplayCoordinator gameplayCoordinator = Container.Resolve<IGameplayCoordinator>();
            
            GameResultModel model = new GameResultModel(loadingProvider, gameplayCoordinator);
            
            Container
                .Bind<GameResultPresenter>()
                .AsSingle()
                .WithArguments(model, _gameResultView);
        }
        
        private void BindMediator()
        {
            Container
                .Bind<IGameMediator>()
                .To<GameMediator>()
                .AsSingle();
        }
    }
}