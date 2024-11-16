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
            BindGameHud();
            BindGameResult();
        }

        private void BindGameHud()
        {
            GameHudModel model = new GameHudModel();
            GameHudPresenter presenter = new GameHudPresenter(model, _gameHudView);
            
            Container
                .Bind<GameHudPresenter>()
                .FromInstance(presenter)
                .AsSingle();
        }
        
        private void BindGameResult()
        {
            ILoadingProvider loadingProvider = Container.Resolve<ILoadingProvider>();
            
            GameResultModel model = new GameResultModel(loadingProvider);
            GameResultPresenter presenter = new GameResultPresenter(model, _gameResultView);
            
            Container
                .Bind<GameResultPresenter>()
                .FromInstance(presenter)
                .AsSingle();
        }
    }
}