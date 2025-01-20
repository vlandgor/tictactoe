using Cysharp.Threading.Tasks;
using Runtime.GameModes.ClassicMode.Board;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class LocalBoardManager : MonoBehaviour, IBoardManager
    {
        [SerializeField] private LocalTilesFactory localTilesFactory;
        
        private MatchBoard matchBoard;
        
        
        
        public async UniTask Initialize(IBoardData boardData)
        {
            await GenerateBoard(boardData);
        }

        private async UniTask GenerateBoard(IBoardData boardData)
        {
            switch (boardData)
            {
                case ClassicBoardData classicBoardData:
                    matchBoard = new ClassicBoard(classicBoardData);
                    break;
            }
        }
    }
}