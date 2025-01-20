using System;
using Cysharp.Threading.Tasks;
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

        public async UniTask Initialize(IMatchData matchData, IBoardData boardData)
        {
            await InitializeRoundManager(matchData);
            await InitializeBoardManager(matchData, boardData);
            await InitializeMatchManager(matchData);
        }

        private async UniTask InitializeMatchManager(IMatchData matchData)
        {
            // Resolve the appropriate match manager instance
            IMatchManager matchManager = matchData switch
            {
                LocalMatchData => localMatchManager,
                NetworkMatchData => networkMatchManager,
                _ => throw new InvalidOperationException($"Unsupported match data type: {matchData.GetType()}")
            };

            // Bind and resolve the match manager
            Container
                .Bind<IMatchManager>()
                .To(matchManager.GetType())
                .FromInstance(matchManager)
                .AsSingle();

            await matchManager.Initialize(matchData);
        }

        private async UniTask InitializeBoardManager(IMatchData matchData, IBoardData boardData)
        {
            // Resolve the appropriate board manager instance
            IBoardManager boardManager = matchData switch
            {
                LocalMatchData => localBoardManager,
                NetworkMatchData => networkBoardManager,
                _ => throw new InvalidOperationException($"Unsupported match data type: {matchData.GetType()}")
            };

            // Bind and resolve the board manager
            Container
                .Bind<IBoardManager>()
                .To(boardManager.GetType())
                .FromInstance(boardManager)
                .AsSingle();

            await boardManager.Initialize(boardData);
        }

        private async UniTask InitializeRoundManager(IMatchData matchData)
        {
            // Implement round manager initialization logic if necessary
            await UniTask.CompletedTask;
        }
    }
}
