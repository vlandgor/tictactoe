using Runtime.BoardManager;
using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class MatchInstaller : MonoInstaller
    {
        [Header("Match Managers")]
        [SerializeField] private LocalMatchManager localMatchManager;
        [SerializeField] private NetworkMatchManager networkMatchManager;

        [Header("Board Managers")]
        [SerializeField] private LocalBoardManager localBoardManager;
        [SerializeField] private NetworkBoardManager networkBoardManager;

        public override void InstallBindings()
        {
            BindBoardManager();
            BindMatchManager();
        }

        private void BindMatchManager()
        {
            Container
                .Bind<IMatchManager>()
                .WithId(MatchType.Local)
                .To<LocalMatchManager>()
                .FromInstance(localMatchManager)
                .AsTransient();

            Container
                .Bind<IMatchManager>()
                .WithId(MatchType.Network)
                .To<NetworkMatchManager>()
                .FromInstance(networkMatchManager)
                .AsTransient();
        }
        private void BindBoardManager()
        {
            Container
                .Bind<IBoardManager>()
                .WithId(MatchType.Local)
                .To<LocalBoardManager>()
                .FromInstance(localBoardManager)
                .AsTransient();

            Container
                .Bind<IBoardManager>()
                .WithId(MatchType.Network)
                .To<NetworkBoardManager>()
                .FromInstance(networkBoardManager)
                .AsTransient();
        }
    }
}
