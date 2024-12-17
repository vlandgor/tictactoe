using Runtime.Extensions;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Presenters;
using Runtime.UI.Menu.Views;
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
            Container.BindUIPresenter<MenuGameSetupBasePresenter, MenuGameSetupBaseModel, MenuGameSetupBaseView>(_viewsFactory);
        }
        
        private void BindMenuSettings()
        {
            Container.BindUIPresenter<MenuSettingsBasePresenter, MenuSettingsBaseModel, MenuSettingsBaseView>(_viewsFactory);
        }
        
        private void BindMenuShop()
        {
            Container.BindUIPresenter<MenuShopBasePresenter, MenuShopModel, MenuShopBaseView>(_viewsFactory);
        }
        
        private void BindMenuHud()
        {
            Container.BindUIPresenter<MenuHudBasePresenter, MenuHudModel, MenuHudBaseView>(_viewsFactory);
        }
    }
}