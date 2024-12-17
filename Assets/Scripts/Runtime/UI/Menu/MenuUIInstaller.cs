using Runtime.Extensions;
using Runtime.UI.MenuHud;
using Runtime.UI.MenuMatchSetup;
using Runtime.UI.MenuSettings;
using Runtime.UI.MenuShop;
using UnityEngine;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MenuUIInstaller : MonoInstaller
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
                .Bind<IMenuMediator>()
                .To<MenuMediator>()
                .AsSingle();
        }
        
        private void BindPresenters()
        {
            Container.BindUIPresenter<MenuHudPresenter, MenuHudModel, MenuHudView>(_viewsFactory);
            Container.BindUIPresenter<MenuSettingsPresenter, MenuSettingsModel, MenuSettingsView>(_viewsFactory);
            Container.BindUIPresenter<MenuShopPresenter, MenuShopModel, MenuShopView>(_viewsFactory);
            Container.BindUIPresenter<MenuMatchSetupPresenter, MenuMatchSetupModel, MenuMatchSetupView>(_viewsFactory);
        }
    }
}