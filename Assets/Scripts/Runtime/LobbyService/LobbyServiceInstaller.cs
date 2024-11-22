using UnityEngine;
using Zenject;

namespace Runtime.LobbyService
{
    public class LobbyServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLobby();
        }

        private void BindLobby()
        {
            Container
                .Bind<ILobbyService>()
                .To<LobbyService>()
                .AsSingle();
        }
    }
}