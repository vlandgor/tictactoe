using System;
using Cysharp.Threading.Tasks;
using Runtime.AuthenticationService;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class AuthenticationOperation : ILoadingOperation
    {
        private IAuthenticationService _authenticationService;
        
        public string Description => "Authenticating...";

        public AuthenticationOperation(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(0.5f);
            
            _authenticationService.SignIn();
            
            onProgress?.Invoke(1f);
        }
    }
}