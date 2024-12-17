using Runtime.Extensions;
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
            Container.BindUIPresenter<GameHudBasePresenter, GameHudBaseModel, GameHudBaseView>(_viewsFactory);
        }
        
        private void BindGameResult()
        {
            Container.BindUIPresenter<GameResultBasePresenter, GameResultBaseModel, GameResultBaseView>(_viewsFactory);
        }
    }
}