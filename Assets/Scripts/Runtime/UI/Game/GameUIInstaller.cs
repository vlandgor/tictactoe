using Runtime.UI.Game.Models;
using Runtime.UI.Game.Presenters;
using Runtime.UI.Game.Views;
using UnityEngine;
using Zenject;

namespace Runtime.UI.Game
{
    public class GameUIInstaller : MonoInstaller
    {
        [SerializeField] private ViewsFactory _viewsFactory;
        
        public override void InstallBindings()
        {
            BindMediator();
            
            BindGameHud();
            BindGameResult();
        }
        
        private void BindMediator()
        {
            Container
                .Bind<IGameMediator>()
                .To<GameMediator>()
                .AsSingle();
        }

        private void BindGameHud()
        {
            GameHudModel model = Container.Instantiate<GameHudModel>();
            GameHudView view = _viewsFactory.Get<GameHudView>();
            
            Container
                .Bind<GameHudPresenter>()
                .AsSingle()
                .WithArguments(model, view);
            
            view.Initialize(Container.Resolve<GameHudPresenter>());
        }
        
        private void BindGameResult()
        {
            GameResultModel model = Container.Instantiate<GameResultModel>();
            GameResultView view = _viewsFactory.Get<GameResultView>();
            
            Container
                .Bind<GameResultPresenter>()
                .AsSingle()
                .WithArguments(model, view);
            
            view.Initialize(Container.Resolve<GameResultPresenter>());
        }
    }
}