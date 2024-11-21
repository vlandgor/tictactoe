using Runtime.AudioService;
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
        [SerializeField] private MenuSettingsView _menuSettingsView;
        
        public override void InstallBindings()
        {
            BindMediator();
            
            BindMenuHud();
            BindMenuSettings();
        }

        private void BindMenuHud()
        {
            IMenuMediator mediator = Container.Resolve<IMenuMediator>();
            ILoadingProvider loadingProvider = Container.Resolve<ILoadingProvider>();
            IMarksProvider marksProvider = Container.Resolve<IMarksProvider>();
            IAudioService audioService = Container.Resolve<IAudioService>();
            
            MenuHudModel model = new MenuHudModel(loadingProvider, marksProvider, audioService);

            Container
                .Bind<MenuHudPresenter>()
                .AsSingle()
                .WithArguments(mediator, model, _menuHudView);
        }
        
        private void BindMenuSettings()
        {
            MenuSettingsModel model = new MenuSettingsModel();

            Container
                .Bind<MenuSettingsPresenter>()
                .AsSingle()
                .WithArguments(model, _menuSettingsView);
        }
        
        private void BindMediator()
        {
            Container
                .Bind<IMenuMediator>()
                .To<MenuMediator>()
                .AsSingle();
        }
    }
}