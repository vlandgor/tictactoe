using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

using UAS = Unity.Services.Authentication.AuthenticationService;

namespace Runtime.Authentication
{
    public class GuestAuthenticationProvider : IAuthenticationProvider
    {
        private TaskCompletionSource<bool> _signInTaskCompletionSource;
        
        public GuestAuthenticationProvider(TaskCompletionSource<bool> signInTaskCompletionSource)
        {
            _signInTaskCompletionSource = signInTaskCompletionSource;
        }
        
        public async UniTask SignIn()
        {
            await SignInAsGuest();
        }

        public async UniTask SignOut()
        {
            
        }
        
        private async UniTask SignInAsGuest()
        {
            try
            {
                await UAS.Instance.SignInAnonymouslyAsync();
                _signInTaskCompletionSource.SetResult(true);
            }
            catch (AuthenticationException ex)
            {
                Debug.LogError($"AuthenticationException: {ex.Message}");
                // Handle specific AuthenticationException error codes here
            }
            catch (RequestFailedException ex)
            {
                Debug.LogError($"RequestFailedException: {ex.Message}");
                // Handle specific RequestFailedException error codes here
            }
        }
    }
}