using Cysharp.Threading.Tasks;
using Runtime.GameModes.ClassicMode.Board;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class LocalBoardManager : MonoBehaviour, IBoardManager
    {
        [SerializeField] private LocalTilesFactory localTilesFactory;
        
        private Board _board;
        
        
        
        public async UniTask Initialize(IBoardData boardData)
        {
            await GenerateBoard(boardData);
        }

        private async UniTask GenerateBoard(IBoardData boardData)
        {
            switch (boardData)
            {
                case ClassicBoardData classicBoardData:
                    _board = new ClassicBoard(classicBoardData);
                    break;
            }
        }
    }
}