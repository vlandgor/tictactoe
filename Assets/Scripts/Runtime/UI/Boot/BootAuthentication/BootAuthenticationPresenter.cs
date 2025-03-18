using Runtime.Authentication;
using Runtime.UI.Boot;

namespace Runtime.UI.BootAuthentication
{
    public class BootAuthenticationPresenter : BasePresenter
    {
        private readonly IBootMediator _bootMediator;
        private readonly BootAuthenticationModel _model;
        private readonly BootAuthenticationView _view;
        
        public BootAuthenticationPresenter(
            IBootMediator bootMediator,
            BootAuthenticationModel model, BootAuthenticationView view)
        {
            _bootMediator = bootMediator;
            _model = model;
            _view = view;
        }
        
        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();

        public void SignInAsGuest() => _model.SignIn(AuthenticationServiceType.Guest);
        public void SignInWithUnity() => _model.SignIn(AuthenticationServiceType.Unity);
    }
}