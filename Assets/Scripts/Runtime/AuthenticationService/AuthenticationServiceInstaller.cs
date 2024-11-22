using Zenject;

namespace Runtime.AuthenticationService
{
    public class AuthenticationServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindAuthentication();
        }

        private void BindAuthentication()
        {
            Container
                .Bind<IAuthenticationService>()
                .To<AuthenticationService>()
                .AsSingle();
        }
    }
}