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
        public event Action<BoardPosition> OnTileClicked;
        
        public event Action<IPlayer> OnWinnerDetected;
        public event Action OnDrawDetected;
        
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
            
            _boardVisual.OnTileClicked += HandleTileClicked;
        }
        
        private void OnDestroy()
        {
            _boardVisual.OnTileClicked -= HandleTileClicked;
        }

        public async UniTask PlacePiece(IPlayer player, BoardPosition boardPosition, PieceType pieceType, Action piecePlaced)
        {
            _board.PlacePiece(player, boardPosition);
            
            await _boardVisual.PlacePiece(_pieceProvider.GetPiece(player.SetIndex, PieceType.Cross), boardPosition);

            if (_board.CheckForWinner(out IPlayer winner))
            {
                OnWinnerDetected?.Invoke(winner);
                return;
            }

            if (_board.CheckForDraw())
            {
                OnDrawDetected?.Invoke();
                return;
            }
            
            piecePlaced?.Invoke();
        }

        public async UniTask ClearBoard()
        {
            _board.ClearBoard();
            await _boardVisual.ClearBoard();
        }
        
        private void HandleTileClicked(BoardPosition boardPosition)
        {
            if (_board.ValidateInput(boardPosition))
            {
                OnTileClicked?.Invoke(boardPosition);
            }
        }
    }
}