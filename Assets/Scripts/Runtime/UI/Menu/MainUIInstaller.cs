using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Presenters;
using Runtime.UI.Menu.Views;
using UnityEngine;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MainUIInstaller : MonoInstaller
    {
        [SerializeField] private ViewsFactory _viewsFactory;
        
        public override void InstallBindings()
        {
            BindMediator();
            
            BindMenuHud();
            BindMenuSettings();
            BindMenuShop();
            BindMatchSetup();
        }
        
        private void BindMediator()
        {
            Container
                .Bind<IMenuMediator>()
                .To<MenuMediator>()
                .AsSingle();
        }
        
        private void BindMatchSetup()
        {
            MenuGameSetupModel model = Container.Instantiate<MenuGameSetupModel>();
            MenuGameSetupView view = _viewsFactory.Get<MenuGameSetupView>();
            
            Container
                .Bind<MenuGameSetupPresenter>()
                .AsSingle()
                .WithArguments(model, view);
            
            view.Initialize(Container.Resolve<MenuGameSetupPresenter>());
        }
        
        private void BindMenuSettings()
        {
            MenuSettingsModel model = Container.Instantiate<MenuSettingsModel>();
            MenuSettingsView view = _viewsFactory.Get<MenuSettingsView>();

            Container
                .Bind<MenuSettingsPresenter>()
                .AsSingle()
                .WithArguments(model, view);
            
            view.Initialize(Container.Resolve<MenuSettingsPresenter>());
        }
        
        private void BindMenuShop()
        {
            MenuShopModel model = Container.Instantiate<MenuShopModel>();
            MenuShopView view = _viewsFactory.Get<MenuShopView>();

            Container
                .Bind<MenuShopPresenter>()
                .AsSingle()
                .WithArguments(model, view);
            
            view.Initialize(Container.Resolve<MenuShopPresenter>());
        }
        
        private void BindMenuHud()
        {
            MenuHudModel model = Container.Instantiate<MenuHudModel>();
            MenuHudView view = _viewsFactory.Get<MenuHudView>();

            Container
                .Bind<MenuHudPresenter>()
                .AsSingle()
                .WithArguments(model, view);
            
            view.Initialize(Container.Resolve<MenuHudPresenter>());
        }
    }
}