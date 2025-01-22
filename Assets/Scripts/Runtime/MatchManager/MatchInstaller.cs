using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class MatchInstaller : MonoInstaller
    {
        [Header("Match Managers")]
        [SerializeField] private LocalMatchManager localMatchManager;
        [SerializeField] private NetworkMatchManager networkMatchManager;

        public override void InstallBindings()
        {
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

    }
}
