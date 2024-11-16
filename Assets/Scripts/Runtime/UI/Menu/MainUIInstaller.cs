using Runtime.LoadingProvider;
using Runtime.Marks;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Presenters;
using Runtime.UI.Menu.Views;
using UnityEngine;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MainUIInstaller : MonoInstaller
    {
        [SerializeField] private MenuHudView _menuHudView;
        
        public override void InstallBindings()
        {
            BindMenuHud();
        }

        private void BindMenuHud()
        {
            ILoadingProvider loadingProvider = Container.Resolve<ILoadingProvider>();
            IMarksProvider marksProvider = Container.Resolve<IMarksProvider>();
            
            MenuHudModel model = new MenuHudModel(loadingProvider, marksProvider);
            MenuHudPresenter hudPresenter = new MenuHudPresenter(model, _menuHudView);
            
            Container
                .Bind<MenuHudPresenter>()
                .FromInstance(hudPresenter)
                .AsSingle();
        }
    }
}