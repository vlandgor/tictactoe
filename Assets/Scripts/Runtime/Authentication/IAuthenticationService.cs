﻿using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Runtime.Authentication
{
    public interface IAuthenticationService
    {
        public TaskCompletionSource<bool> SignInCompletionSource { get; }
        
        public UniTask Initialize();
        public UniTask SignIn(AuthenticationServiceType serviceType);
        public UniTask SignOut();
    }
}