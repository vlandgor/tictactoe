using Runtime.Extensions;
using Runtime.UI.GameHud;
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
            BindPresenters();
        }

        private void BindMediator()
        {
            Container
                .Bind<IGameMediator>()
                .To<GameMediator>()
                .AsSingle();
        }
        
        private void BindPresenters()
        {
            Container.BindUIPresenter<GameHudPresenter, GameHudModel, GameHudView>(_viewsFactory);
        }
    }
}