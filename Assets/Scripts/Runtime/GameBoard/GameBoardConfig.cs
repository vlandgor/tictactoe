using UnityEngine;

namespace Runtime.GameBoard
{
    [CreateAssetMenu(fileName = "GameBoardConfig", menuName = "Playcbo/Configs/Game Board Config", order = 0)]
    public class GameBoardConfig : ScriptableObject
    {
        [SerializeField] private Vector2Int _boardSize;
        public Vector2Int BoardSize => _boardSize;
        
        [SerializeField] private float _boardTileSize;
        public float BoardTileSize => _boardTileSize;
        
        [SerializeField] private float _boardLineSize;
        public float BoardLineSize => _boardLineSize;
    }
}