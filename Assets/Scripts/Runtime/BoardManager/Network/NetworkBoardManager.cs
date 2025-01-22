using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.BoardManager
{
    public class NetworkBoardManager : MonoBehaviour, IBoardManager
    {
        public UniTask Initialize(IBoard board, IBoardVisual boardVisual, IBoardData boardData)
        {
            throw new System.NotImplementedException();
        }
    }
}