using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.BoardManager.Local;
using Runtime.BotService;
using Runtime.GamePieces;
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

        private int roundNumber;

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

            _boardManager.OnMoveRequested += BoardManager_TileClicked;

            await StartMatch();
        }

        private void OnDestroy()
        {
            _boardManager.OnMoveRequested -= BoardManager_TileClicked;
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
        
        private async void BoardManager_TileClicked(BoardPosition boardPosition)
        {
            if (!ValidateInput())
                return;
            
            await _boardManager.PlacePiece(_roundManager.Turn, boardPosition, _roundManager.TurnType);
            
            _boardManager.CheckBoard(out IPlayer winner, out bool draw);
            if (winner != null || draw)
            {
                NextRound(winner);
                return;
            }   
                
            _roundManager.NextTurn();
        }

        private bool ValidateInput()
        {
            if (_roundManager.Turn is BotPlayer)
                return false;
            
            return true;
        }
    }
}