using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class MatchInstaller : MonoInstaller
    {
        [SerializeField] private LocalMatchManager localMatchManager;
        [SerializeField] private NetworkMatchManager networkMatchManager;

        public async UniTask Initialize(IMatchData matchData, IBoardData boardData)
        {
            await InitializeRoundManager(matchData);
            await InitializeBoardManager(matchData, boardData);
            await InitializeMatchManager(matchData);
        }

        private async UniTask InitializeMatchManager(IMatchData matchData)
        {
            var matchManagerType = matchData switch
            {
                LocalMatchData => typeof(LocalMatchManager),
                NetworkMatchData => typeof(NetworkMatchManager)
            };
            
            Container
                .Bind<IMatchManager>()
                .To(matchManagerType)
                .AsSingle();
            
            var matchManager = Container.Resolve<IMatchManager>();
            await matchManager.Initialize(matchData);
        }
        
        private async UniTask InitializeBoardManager(IMatchData matchData, IBoardData boardData)
        {
            var boardManagerType = matchData switch
            {
                LocalMatchData => typeof(LocalBoardManager),
                NetworkMatchData => typeof(NetworkBoardManager)
            };

            Container
                .Bind<IBoardManager>()
                .To(boardManagerType)
                .AsSingle();

            var boardManager = Container.Resolve<IBoardManager>();
            await boardManager.Initialize(boardData);
        }
        
        private async UniTask InitializeRoundManager(IMatchData matchData)
        {
            
        }
    }
}