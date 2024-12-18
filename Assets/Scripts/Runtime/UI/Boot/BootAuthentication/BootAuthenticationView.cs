using UnityEngine.UIElements;

namespace Runtime.UI.BootAuthentication
{
    public class BootAuthenticationView : BaseView
    {
        private Button _loginWithUnityButton;
        private Button _loginAsGuestButton;
        
        private BootAuthenticationPresenter BootAuthenticationPresenter => BasePresenter as BootAuthenticationPresenter;
        
        protected override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _loginWithUnityButton = _visual.Q<Button>("LoginWithUnityButton");
            _loginWithUnityButton.clicked += BootAuthenticationPresenter.SignInWithUnity;
            
            _loginAsGuestButton = _visual.Q<Button>("LoginAsGuestButton");
            _loginAsGuestButton.clicked += BootAuthenticationPresenter.SignInAsGuest;
        }
    }
}