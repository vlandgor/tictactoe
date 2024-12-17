using Runtime.UI.BootAuthentication;
using Zenject;

namespace Runtime.UI.Boot
{
    public class BootMediator : IBootMediator
    {
        private readonly LazyInject<BootAuthenticationPresenter> _authenticationPresenter;
        
        public BootMediator(
            LazyInject<BootAuthenticationPresenter> authenticationPresenter)
        {
            _authenticationPresenter = authenticationPresenter;
        }
        
        public void ShowAuthentication() => _authenticationPresenter.Value.EnableView();
    }
}