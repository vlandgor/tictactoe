using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.GamePlayer;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class NetworkMatchManager : NetworkBehaviour, IMatchManager
    {
        private IBoardManager _boardManager;
        private RoundManager _roundManager;
        
        private NetworkMatchData _matchData;
        private Round[] rounds;

        private int roundNumber;
        
        [Inject]
        public void Construct(DiContainer container)
        {
            _boardManager = container.ResolveId<IBoardManager>(MatchType.Network);
        }
        
        public override void OnNetworkSpawn()
        {
            Debug.Log($"Network was spawned");
        }
        
        public async UniTask Initialize(IMatchData matchData)
        {
            _matchData = (NetworkMatchData)matchData;
            _roundManager = new RoundManager(matchData);
            rounds = new Round[11];

            _boardManager.OnTileClicked += HandleTileClicked;
            _boardManager.OnWinnerDetected += HandleWinnerDetected;
            _boardManager.OnDrawDetected += HandleDrawDetected;
            
            await StartMatch();
        }
        
        private void OnDestroy()
        {
            _boardManager.OnTileClicked -= HandleTileClicked;
            _boardManager.OnWinnerDetected -= HandleWinnerDetected;
            _boardManager.OnDrawDetected -= HandleDrawDetected;
        }

        public async UniTask StartMatch()
        {
            _roundManager.FirstRound(_matchData.Players[0]);
        }

        public async UniTask FinishMatch()
        {
            
        }
        
        private void NextRound(IPlayer winner)
        {
            _roundManager.FinishRound(winner, out Round round);
            rounds[roundNumber] = round;
            roundNumber++;

            _boardManager.ClearBoard();
            _roundManager.NextRound();
        }
        
        private async void HandleTileClicked(Vector2Int coordinate)
        {
            if (!ValidateInput())
                return;
            
            //await _boardManager.PlacePiece(_roundManager.Turn, coordinate, () => _roundManager.NextTurn());
        }
        
        private void HandleWinnerDetected(IPlayer winner)
        {
            NextRound(winner);
        }
        
        private void HandleDrawDetected()
        {
            NextRound(null);
        }
        
        private bool ValidateInput()
        {
            return true;
        }
    }
}