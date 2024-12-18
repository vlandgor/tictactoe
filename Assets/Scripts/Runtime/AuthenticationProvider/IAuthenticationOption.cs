using Cysharp.Threading.Tasks;

namespace Runtime.AuthenticationProvider
{
    public interface IAuthenticationOption
    {
        public UniTask Login();
        public UniTask Logout();
    }
}