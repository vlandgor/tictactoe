using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.GamePlayer;
using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class LocalMatchManager : MonoBehaviour, IMatchManager
    {
        private IBoardManager _boardManager;
        private RoundManager _roundManager;
        
        private LocalMatchData _matchData;
        private Round[] rounds;

        private int round;

        [Inject]
        public void Construct(DiContainer container)
        {
            _boardManager = container.ResolveId<IBoardManager>(MatchType.Local);
        }
        
        public async UniTask Initialize(IMatchData matchData)
        {
            _matchData = (LocalMatchData)matchData;
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
            _roundManager.StartRound(_matchData.Players[0]);
        }

        public async UniTask FinishMatch()
        {
            
        }
        
        private async void HandleTileClicked(Vector2Int coordinate)
        {
            if (!ValidateInput())
                return;
            
            await _boardManager.PlacePiece(_roundManager.Turn, coordinate, () => _roundManager.NextTurn());
        }
        
        private void HandleWinnerDetected(IPlayer winner)
        {
            rounds[round] = _roundManager.FinishRound(winner);
            round++;
        }
        
        private void HandleDrawDetected()
        {
            rounds[round] = _roundManager.FinishRound(null);
            round++;
        }

        private bool ValidateInput()
        {
            //TODO: Add validation
            
            return true;
        }
    }
}