using Cysharp.Threading.Tasks;

namespace Runtime.RelayService
{
    public interface IRelayService
    {
        UniTask<string> HostRelay();
        UniTask JoinRelay(string joinCode);
    }
}