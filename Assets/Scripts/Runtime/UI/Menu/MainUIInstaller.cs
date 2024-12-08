using Runtime.AudioService;
using Runtime.ConfigProvider;
using Runtime.LoadingProvider;
using Runtime.ShopService;
using Runtime.Tokens;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Presenters;
using Runtime.UI.Menu.Views;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MainUIInstaller : MonoInstaller
    {
        [SerializeField] private MenuHudView _menuHudView;
        [SerializeField] private MenuSettingsView _menuSettingsView;
        [SerializeField] private MenuShopView _menuShopView;
        [SerializeField] private MenuGameSetupView _menuGameSetupView;
        
        public override void InstallBindings()
        {
            BindMediator();
            
            BindMenuHud();
            BindMenuSettings();
            BindMenuShop();
            BingGameSetup();
        }
        
        private void BindMediator()
        {
            Container
                .Bind<IMenuMediator>()
                .To<MenuMediator>()
                .AsSingle();
        }
        
        private void BingGameSetup()
        {
            IMenuMediator mediator = Container.Resolve<IMenuMediator>();
            ILoadingProvider loadingProvider = Container.Resolve<ILoadingProvider>();
            ITokensProvider tokensService = Container.Resolve<ITokensProvider>();
            IAudioService audioService = Container.Resolve<IAudioService>();
            IConfigProvider configProvider = Container.Resolve<IConfigProvider>();
            
            MenuGameSetupModel setupModel = new MenuGameSetupModel(loadingProvider, tokensService, audioService, configProvider);

            Container
                .Bind<MenuGameSetupPresenter>()
                .AsSingle()
                .WithArguments(mediator, setupModel, _menuGameSetupView);
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
    }
}