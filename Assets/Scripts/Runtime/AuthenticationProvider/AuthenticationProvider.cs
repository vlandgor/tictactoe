using System;
using Cysharp.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Authentication.PlayerAccounts;
using Unity.Services.Core;
using UnityEngine;

namespace Runtime.AuthenticationProvider
{
    public class AuthenticationProvider : IAuthenticationProvider, IDisposable
    {
        public AuthenticationProvider()
        {
            PlayerAccountService.Instance.SignedIn += HandleSignInWithUnityAsync;
        }

        public void Dispose()
        {
            PlayerAccountService.Instance.SignedIn -= HandleSignInWithUnityAsync;
        }
        
        public async UniTask LoginWithUnity() => await PlayerAccountService.Instance.StartSignInAsync();

        public async UniTask LoginAsGuest()
        {
            Debug.Log("Attempting to login as Guest...");

            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log("Sign-in as Guest successful.");
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
        
        private async void HandleSignInWithUnityAsync()
        {
            try
            {
                await AuthenticationService.Instance.SignInWithUnityAsync(AuthenticationService.Instance.AccessToken);
                Debug.Log("Sign-in with Unity successful.");
            }
            catch (AuthenticationException ex)
            {
                Debug.LogError($"AuthenticationException: {ex.Message}");
            }
            catch (RequestFailedException ex)
            {
                Debug.LogError($"RequestFailedException: {ex.Message}");
            }
        }
    }
}
