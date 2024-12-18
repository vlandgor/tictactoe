using Cysharp.Threading.Tasks;

namespace Runtime.AuthenticationProvider
{
    public interface IAuthenticationProvider
    {
        public UniTask LoginWithUnity();
        public UniTask LoginAsGuest();
    }
}