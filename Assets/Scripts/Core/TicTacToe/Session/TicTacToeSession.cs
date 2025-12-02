using System;
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
        
        public TurnHandler TurnHandler { get; private set; }
        public ScoreTracker ScoreTracker { get; private set; }

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
            ProcessMove(pieceType, boardTile);
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
            RoundStarted?.Invoke();

            _ticTacToeBoard.ClearBoard();
            
            TurnHandler.SetActivePlayer(PieceType.Cross);

            TurnChanged?.Invoke(TurnHandler.ActivePlayer);
        }
        
        private void ProcessRoundFinish(PieceType pieceType)
        {
            RoundFinished?.Invoke();

            if (pieceType == PieceType.None)
            {
                TurnHandler.SwapStartingPlayers();
                ProcessRoundStart();
                return;
            }

            ScoreTracker.IncrementScore(pieceType);

            if (ScoreTracker.TryGetWinner(out PieceType gameWinner))
            {
                ProcessGameFinish(gameWinner);
                return;
            }
            
            TurnHandler.SwapStartingPlayers();
            ProcessRoundStart();
        }

        private void ProcessMove(PieceType pieceType, BoardTile boardTile)
        {
            if(!ValidateMove(boardTile, pieceType)) 
                return;
            
            _ticTacToeBoard.PlacePiece(pieceType, boardTile);
            
            if (_ticTacToeBoard.TryGetWinnerOrDraw(out PieceType roundWinner))
            {
                ProcessRoundFinish(roundWinner);
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
