using Runtime.Authentication;

namespace Runtime.UI.BootAuthentication
{
    public class BootAuthenticationModel : BaseModel
    {
        private readonly IAuthenticationService _authenticationService;
        
        public BootAuthenticationModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        public void SignIn(AuthenticationServiceType serviceType)
        {
            _authenticationService.SignIn(serviceType);
        }
    }
}