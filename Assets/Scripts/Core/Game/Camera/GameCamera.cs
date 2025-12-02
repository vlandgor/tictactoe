using Core.TicTacToe.Board;
using UnityEngine;

namespace Core.Game.Camera
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;

        public UnityEngine.Camera Camera => _camera;
        
        public void Initialize(IBoardData boardData)
        {
            _camera.orthographicSize = boardData.BoardSize.width + 0.5f;
        }
    }
}