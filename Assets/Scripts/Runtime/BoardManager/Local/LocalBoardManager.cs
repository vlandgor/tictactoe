using System;
using Cysharp.Threading.Tasks;
using Runtime.GamePlayer;
using Runtime.MatchManager;
using UnityEngine;
using Zenject;

namespace Runtime.BoardManager
{
    public class LocalBoardManager : MonoBehaviour, IBoardManager
    {
        public event Action<Vector2Int> OnTileClicked; 
        
        [SerializeField] private LocalTilesFactory localTilesFactory;
        
        private IBoardData _boardData;
        
        private Board _board;
        private BoardVisual _boardVisual;

        [Inject]
        public void Construct(DiContainer container)
        {
            _board = (Board)container.ResolveId<IBoard>(MatchMode.Classic);
            _boardVisual = (BoardVisual)container.ResolveId<IBoardVisual>(MatchMode.Classic);
        }
        
        public async UniTask Initialize(IBoardData boardData)
        {
            _boardData = boardData;
            
            await _board.Initialize(boardData);
            
            _boardVisual.SetFactories(localTilesFactory);
            await _boardVisual.Initialize(boardData);
            
            _boardVisual.OnTileClicked += HandleTileClicked;
        }

        public async UniTask PlacePiece(IPlayer player, Vector2Int coordinate)
        {
            Debug.Log($"LocalBoardManager: place piece");
            
            _board.PlacePiece(player, coordinate);
            await _boardVisual.PlacePiece(player.SetIndex, coordinate);
        }

        private void OnDestroy()
        {
            _boardVisual.OnTileClicked -= HandleTileClicked;
        }
        
        private void HandleTileClicked(Vector2Int coordinate)
        {
            Debug.Log("Tile Clicked");
            
            if (_board.ValidateInput(coordinate))
            {
                Debug.Log("Input correct");
                OnTileClicked?.Invoke(coordinate);
            }
        }
    }
}