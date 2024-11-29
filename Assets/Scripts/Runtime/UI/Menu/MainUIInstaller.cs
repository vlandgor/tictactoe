using Runtime.AudioService;
using Runtime.LoadingProvider;
using Runtime.Marks;
using Runtime.ShopService;
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
        [SerializeField] private MenuShopView _menuShopView;
        [SerializeField] private MenuCreateGameView _menuCreateGameView;
        
        public override void InstallBindings()
        {
            BindMediator();
            
            BindMenuHud();
            BindMenuSettings();
            BindMenuShop();
            BingCreateGame();
        }
        
        private void BindMediator()
        {
            Container
                .Bind<IMenuMediator>()
                .To<MenuMediator>()
                .AsSingle();
        }

        private void BindMenuHud()
        {
            IMenuMediator mediator = Container.Resolve<IMenuMediator>();
            IAudioService audioService = Container.Resolve<IAudioService>();
            
            MenuHudModel model = new MenuHudModel(audioService);

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
        
        private void BindMenuShop()
        {
            IShopService shopService = Container.Resolve<IShopService>();
            
            MenuShopModel model = new MenuShopModel(shopService);

            Container
                .Bind<MenuShopPresenter>()
                .AsSingle()
                .WithArguments(model, _menuShopView);
        }

        private void BingCreateGame()
        {
            IMenuMediator mediator = Container.Resolve<IMenuMediator>();
            ILoadingProvider loadingProvider = Container.Resolve<ILoadingProvider>();
            IMarksProvider marksService = Container.Resolve<IMarksProvider>();
            IAudioService audioService = Container.Resolve<IAudioService>();
            
            MenuCreateGameModel model = new MenuCreateGameModel(loadingProvider, marksService, audioService);

            Container
                .Bind<MenuCreateGamePresenter>()
                .AsSingle()
                .WithArguments(mediator, model, _menuCreateGameView);
        }
    }
}