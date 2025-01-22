using Cysharp.Threading.Tasks;
using Runtime.GameModes.ClassicMode.Board;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class LocalBoardManager : MonoBehaviour, IBoardManager
    {
        [SerializeField] private LocalTilesFactory localTilesFactory;

        private IBoardData _boardData;
        
        private IBoard _board;
        private IBoardVisual _boardVisual;
        
        public async UniTask Initialize(IBoard board, IBoardVisual boardVisual, IBoardData boardData)
        {
            _board = board;
            _boardVisual = boardVisual;
            _boardData = boardData;

            board.Initialize(boardData);
            
            await GenerateBoard();
        }

        private async UniTask GenerateBoard()
        {
            await _boardVisual.GenerateBoardVisual(_boardData.Size, localTilesFactory.Get<ClassicBoardTile>);
        }
    }
}