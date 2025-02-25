﻿using Runtime.BoardManager;
using UnityEngine;

namespace Runtime.GameModes.ClassicMode.Board
{
    public class ClassicBoardData : IBoardData
    {
        public Vector2Int Size { get; }
        
        public ClassicBoardData(Vector2Int size)
        {
            Size = size;
        }
    }
}