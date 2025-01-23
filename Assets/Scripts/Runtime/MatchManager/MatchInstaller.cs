using Runtime.Tokens;
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
            Debug.Log("Binding local match manager");
            
            Container
                .Bind<IMatchManager>()
                .WithId(MatchType.Local)
                .To<LocalMatchManager>()
                .FromInstance(localMatchManager)
                .AsTransient();
            
            Debug.Log("Binding network match manager");
            
            Container
                .Bind<IMatchManager>()
                .WithId(MatchType.Network)
                .To<NetworkMatchManager>()
                .FromInstance(networkMatchManager)
                .AsTransient();
        }
    }
}
