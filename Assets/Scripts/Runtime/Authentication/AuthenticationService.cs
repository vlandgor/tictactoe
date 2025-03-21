﻿using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.Services.Core;
using UnityEngine;

namespace Runtime.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private GuestAuthenticationProvider _guestAuthenticationProvider;
        private UnityAuthenticationProvider _unityAuthenticationProvider;

        public TaskCompletionSource<bool> SignInCompletionSource { get; private set; } = new();

        public async UniTask Initialize()
        {
            await InitializeUnityServices();
            await InitializeProviders();
        }
        
        public async UniTask SignIn(AuthenticationServiceType serviceType)
        {
            IAuthenticationProvider authenticationProvider;
            
            switch (serviceType)
            {
                case AuthenticationServiceType.Guest:
                    authenticationProvider = _guestAuthenticationProvider;
                    break;
                case AuthenticationServiceType.Unity:
                    authenticationProvider = _unityAuthenticationProvider;
                    break;
                
                default:
                    authenticationProvider = _guestAuthenticationProvider;
                    break;
            }
            
            await authenticationProvider.SignIn();
        }

        public async UniTask SignOut()
        {
            
        }
        
        private async UniTask InitializeUnityServices()
        {
            try
            {
                await UnityServices.InitializeAsync();
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Failed to initialize Unity services: {ex.Message}");
                throw;
            }
        }
        private async UniTask InitializeProviders()
        {
            _guestAuthenticationProvider = new(SignInCompletionSource);
            _unityAuthenticationProvider = new(SignInCompletionSource);
        }
    }
}
