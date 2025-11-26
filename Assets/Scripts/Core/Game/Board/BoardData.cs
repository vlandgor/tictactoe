using UnityEngine;

namespace Core.Game.Board
{
    public class BoardData : IBoardData
    {
        public Vector2Int Size { get; }

        public BoardData(Vector2Int size)
        {
            Size = size;
        }
    }
}