using Cysharp.Threading.Tasks;
using Zenject;

namespace Runtime.Authentication
{
    public class AuthenticationInstaller : MonoInstaller
    {
        public override async void InstallBindings()
        {
            BindAuthentication();
        }
        
        private void BindAuthentication()
        {
            Container
                .Bind<IAuthenticationService>()
                .To<AuthenticationService>()
                .AsSingle();

            IAuthenticationService service = Container.Resolve<IAuthenticationService>();
            service.Initialize().Forget();
        }
    }
}