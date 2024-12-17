using Runtime.Extensions;
using Runtime.UI.BootAuthentication;
using UnityEngine;
using Zenject;

namespace Runtime.UI.Boot
{
    public class BootUIInstaller : MonoInstaller
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
                .Bind<IBootMediator>()
                .To<BootMediator>()
                .AsSingle();
        }
        
        private void BindPresenters()
        {
            Container.BindUIPresenter<BootAuthenticationPresenter, BootAuthenticationModel, BootAuthenticationView>(_viewsFactory);
        }
    }
}