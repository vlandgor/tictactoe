using Core.Game.Camera;
using Core.Game.Input;
using Core.Game.Players;
using Core.TicTacToe.Board;
using Core.TicTacToe.Board.Pieces;
using Core.TicTacToe.Session;
using UnityEngine;

namespace Core.Game.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TicTacToeBoard _ticTacToeBoard;
        [SerializeField] private GamePlayers _gamePlayers;
        [SerializeField] private GameCamera _gameCamera;
        [SerializeField] private TicTacToeSession _ticTacToeSession;
        [SerializeField] private GameInput _gameInput;

        private void Start()
        {
            IBoardData boardData = new BoardData(new BoardSize(3, 3));
            _ticTacToeBoard.Initialize(boardData);
            
            IGamePlayer crossPlayer = new LocalPersonPlayer(PieceType.Cross, _gameInput);
            IGamePlayer circlePlayer = new LocalPersonPlayer(PieceType.Circle, _gameInput);
            _gamePlayers.Initialize(crossPlayer, circlePlayer);
            
            _gameCamera.Initialize(boardData);
            
            _ticTacToeSession.Initialize();
            _ticTacToeSession.StartGame();
        }
    }
}