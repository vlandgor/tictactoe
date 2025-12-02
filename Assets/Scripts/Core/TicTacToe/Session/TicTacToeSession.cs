using System;
using Cysharp.Threading.Tasks;
using Core.TicTacToe.Board;
using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;
using UnityEngine;

namespace Core.TicTacToe.Session
{
    public class TicTacToeSession : MonoBehaviour
    {
        public event Action GameStarted; 
        public event Action GameFinished;
        public event Action RoundStarted;
        public event Action RoundFinished;
        public event Action<PieceType> TurnChanged;

        [SerializeField] private TicTacToeBoard _ticTacToeBoard;
        [SerializeField] private float _winningLineDisplayTime = 1f;

        public TurnHandler TurnHandler { get; private set; }
        public ScoreTracker ScoreTracker { get; private set; }

        private bool _inputLocked;

        public void Initialize()
        {
            TurnHandler = new TurnHandler();
            ScoreTracker = new ScoreTracker(3);

            TurnHandler.TurnChanged += type => TurnChanged?.Invoke(type);
        }

        public void StartGame()
        {
            ProcessGameStart();
        }

        public void FinishGame()
        {   
        }
        
        public void RequestMove(PieceType pieceType, BoardTile boardTile)
        {
            if (_inputLocked)
                return;

            ProcessMove(pieceType, boardTile).Forget();
        }

        private void ProcessGameStart()
        {
            GameStarted?.Invoke();
            ProcessRoundStart();
        }
        
        private void ProcessGameFinish(PieceType gameWinner)
        {
            GameFinished?.Invoke();
        }
        
        private void ProcessRoundStart()
        {
            _inputLocked = false;

            RoundStarted?.Invoke();
            _ticTacToeBoard.ClearBoard();

            TurnHandler.SetActivePlayer(PieceType.Cross);
            TurnChanged?.Invoke(TurnHandler.ActivePlayer);
        }

        
        private void ProcessRoundFinish(PieceType pieceType)
        {
            RoundFinished?.Invoke();

            bool isDraw = pieceType == PieceType.None;

            if (!isDraw)
                ScoreTracker.IncrementScore(pieceType);

            if (!isDraw && ScoreTracker.TryGetWinner(out PieceType gameWinner))
            {
                ProcessGameFinish(gameWinner);
                return;
            }

            TurnHandler.SwapStartingPlayers();
            ProcessRoundStart();
        }

        private async UniTaskVoid ProcessMove(PieceType pieceType, BoardTile boardTile)
        {
            if (!ValidateMove(boardTile, pieceType))
                return;

            _ticTacToeBoard.PlacePiece(pieceType, boardTile);
    
            if (_ticTacToeBoard.TryGetWinnerOrDraw(out WinnerInfo winnerInfo))
            {
                _inputLocked = true;

                bool isWinner = winnerInfo.Winner != PieceType.None;

                if (isWinner)
                    _ticTacToeBoard.DrawWinningLine(winnerInfo);

                await UniTask.Delay(
                    TimeSpan.FromSeconds(_winningLineDisplayTime),
                    cancellationToken: this.GetCancellationTokenOnDestroy()
                );

                ProcessRoundFinish(winnerInfo.Winner);
            }
            else
            {
                TurnHandler.AdvanceTurn();
                TurnChanged?.Invoke(TurnHandler.ActivePlayer);
            }
        }

        private bool ValidateMove(BoardTile boardTile, PieceType pieceType)
        {
            return _ticTacToeBoard.IsTileAvailable(boardTile, pieceType);
        }
    }
}
