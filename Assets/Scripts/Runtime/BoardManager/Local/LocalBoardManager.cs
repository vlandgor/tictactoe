using System;
using Cysharp.Threading.Tasks;
using Runtime.GamePieces;
using Runtime.GamePieces.Local;
using Runtime.GamePlayer;
using Runtime.MatchManager;
using UnityEngine;
using Zenject;

namespace Runtime.BoardManager
{
    public class LocalBoardManager : MonoBehaviour, IBoardManager
    {
        public event Action<Vector2Int> OnTileClicked;
        
        public event Action<IPlayer> OnWinnerDetected;
        public event Action OnDrawDetected;
        
        [SerializeField] private LocalTilesFactory localTilesFactory;
        [SerializeField] private LocalPiecesFactory localPiecesFactory;
        
        private IBoardData _boardData;
        private IPieceProvider _pieceProvider;
        
        private Board _board;
        private BoardVisual _boardVisual;

        [Inject]
        public void Construct(DiContainer container, IPieceProvider pieceProvider)
        {
            _board = (Board)container.ResolveId<IBoard>(MatchMode.Classic);
            _boardVisual = (BoardVisual)container.ResolveId<IBoardVisual>(MatchMode.Classic);

            _pieceProvider = pieceProvider;
        }
        
        public async UniTask Initialize(IBoardData boardData)
        {
            _boardData = boardData;
            
            await _board.Initialize(boardData);
            
            _boardVisual.SetFactories(localTilesFactory, localPiecesFactory);
            await _boardVisual.Initialize(boardData);
            
            _boardVisual.OnTileClicked += HandleTileClicked;
        }
        
        private void OnDestroy()
        {
            _boardVisual.OnTileClicked -= HandleTileClicked;
        }

        public async UniTask PlacePiece(IPlayer player, Vector2Int coordinate, Action piecePlaced)
        {
            _board.PlacePiece(player, coordinate);
            
            await _boardVisual.PlacePiece(_pieceProvider.GetPiece(player.SetIndex, PieceType.Cross), coordinate);

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
        
        private void HandleTileClicked(Vector2Int coordinate)
        {
            if (_board.ValidateInput(coordinate))
            {
                OnTileClicked?.Invoke(coordinate);
            }
        }
    }
}