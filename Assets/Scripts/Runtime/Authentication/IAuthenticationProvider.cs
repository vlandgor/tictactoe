using Cysharp.Threading.Tasks;

namespace Runtime.Authentication
{
    public interface IAuthenticationProvider
    {
        public UniTask SignIn();
        public UniTask SignOut();
    }
}