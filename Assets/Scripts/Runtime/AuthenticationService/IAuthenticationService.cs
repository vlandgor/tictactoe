using Cysharp.Threading.Tasks;

namespace Runtime.AuthenticationService
{
    public interface IAuthenticationService
    {
        public UniTask SignIn();
    }
}