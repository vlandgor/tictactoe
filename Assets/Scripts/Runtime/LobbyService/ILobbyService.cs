using Cysharp.Threading.Tasks;
using Unity.Services.Lobbies.Models;

namespace Runtime.LobbyService
{
    public interface ILobbyService
    {
        UniTask<Lobby> QueryAndJoinLobby();
    }
}