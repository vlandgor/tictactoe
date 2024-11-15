using Runtime.LoadingProvider;
using Runtime.Marks;
using Runtime.UI.MainMenu.Models;
using Runtime.UI.MainMenu.Presenters;
using Runtime.UI.MainMenu.Views;
using UnityEngine;
using Zenject;

namespace Runtime.UI.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _view;
        
        public override void InstallBindings()
        {
            BindMainMenuProvider();
        }

        private void BindMainMenuProvider()
        {
            ILoadingProvider loadingProvider = Container.Resolve<ILoadingProvider>();
            IMarksProvider marksProvider = Container.Resolve<IMarksProvider>();
            
            MainMenuModel model = new MainMenuModel(loadingProvider, marksProvider);
            MainMenuPresenter presenter = new MainMenuPresenter(model, _view);
            
            Container
                .Bind<MainMenuPresenter>()
                .FromInstance(presenter)
                .AsSingle();
        }
    }
}