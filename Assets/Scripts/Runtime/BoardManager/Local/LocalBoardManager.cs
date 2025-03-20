using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager.Local;
using Runtime.GamePieces;
using Runtime.GamePlayer;
using Runtime.MatchManager;
using UnityEngine;
using Zenject;

namespace Runtime.BoardManager
{
    public class LocalBoardManager : MonoBehaviour, IBoardManager
    {
        public event Action<BoardPosition> OnMoveRequested;
        
        private IBoardData _boardData;
        private IPieceProvider _pieceProvider;
        private FactoryProvider.FactoryProvider _factoryProvider;
        
        private Board _board;
        private BoardVisual _boardVisual;

        [Inject]
        public void Construct(DiContainer container, 
            IPieceProvider pieceProvider,
            FactoryProvider.FactoryProvider factoryProvider)
        {
            _board = (Board)container.ResolveId<IBoard>(MatchMode.Classic);
            _boardVisual = (BoardVisual)container.ResolveId<IBoardVisual>(MatchMode.Classic);

            _pieceProvider = pieceProvider;
            _factoryProvider = factoryProvider;
        }
        
        public async UniTask Initialize(IBoardData boardData)
        {
            _boardData = boardData;
            
            await _board.Initialize(boardData);
            
            _boardVisual.SetFactories(_factoryProvider.TilesFactory, _factoryProvider.PiecesFactory);
            await _boardVisual.Initialize(boardData);
            
            _boardVisual.OnTileClicked += BoardVisual_OnTileClicked;
        }
        
        private void OnDestroy()
        {
            _boardVisual.OnTileClicked -= BoardVisual_OnTileClicked;
        }

        public async UniTask PlacePiece(IPlayer player, BoardPosition boardPosition, PieceType pieceType)
        {
            _board.PlacePiece(player, boardPosition);
            
            await _boardVisual.PlacePiece(_pieceProvider.GetPiece(player.SetIndex, pieceType), boardPosition);
        }
        
        public void CheckBoard(out IPlayer winner, out bool draw)
        {
            _board.CheckForWinner(out winner); 
            _board.CheckForDraw(out draw);
        }

        public async UniTask ClearBoard()
        {
            _board.ClearBoard();
            await _boardVisual.ClearBoard();
        }
        
        private void BoardVisual_OnTileClicked(BoardPosition boardPosition)
        {
            if (_board.ValidateInput(boardPosition))
            {
                OnMoveRequested?.Invoke(boardPosition);
            }
        }
    }
}