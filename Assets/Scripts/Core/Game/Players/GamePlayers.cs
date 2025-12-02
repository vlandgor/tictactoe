using System.Collections.Generic;
using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Board.Tiles;
using Core.TicTacToe.Session;
using UnityEngine;

namespace Core.Game.Players
{
    public class GamePlayers : MonoBehaviour
    {
        [SerializeField] private TicTacToeSession _ticTacToeSession;
        
        private readonly Dictionary<PieceType, IGamePlayer> _players = new();

        private PieceType _currentPlayer;

        private void Start()
        {
            _ticTacToeSession.TurnChanged += TicTacToeSessionTurnChanged;
        }

        private void OnDestroy()
        {
            _ticTacToeSession.TurnChanged -= TicTacToeSessionTurnChanged;
            
            foreach (KeyValuePair<PieceType, IGamePlayer> players in _players)
            {
                players.Value.PerformMove -= GamePlayer_PerformMove;
            }
        }

        public void Initialize(IGamePlayer crossPlayer, IGamePlayer circlePlayer)
        {
            _players.Add(PieceType.Cross, crossPlayer);
            _players.Add(PieceType.Circle, circlePlayer);

            foreach (KeyValuePair<PieceType, IGamePlayer> players in _players)
            {
                players.Value.PerformMove += GamePlayer_PerformMove;
            }
        }

        private void TicTacToeSessionTurnChanged(PieceType pieceType)
        {
            _currentPlayer = pieceType;
        }
        
        private void GamePlayer_PerformMove(PieceType pieceType, BoardTile boardTile)
        {
            if(_currentPlayer != pieceType)
                return;
            
            _ticTacToeSession.RequestMove(pieceType, boardTile);
        }
    }
}