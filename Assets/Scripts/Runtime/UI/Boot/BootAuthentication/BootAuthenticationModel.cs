using Runtime.AuthenticationProvider;

namespace Runtime.UI.BootAuthentication
{
    public class BootAuthenticationModel : BaseModel
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        
        public BootAuthenticationModel(IAuthenticationProvider authenticationProvider)
        {
            _authenticationProvider = authenticationProvider;
        }
        
        public void LoginWithUnity()
        {
            _authenticationProvider.LoginWithUnity();
        }
        
        public void LoginAsGuest()
        {
            _authenticationProvider.LoginAsGuest();
        }
    }
}