using System;
using UnityEngine;

namespace Core.TicTacToe.Board
{
    [Serializable]
    public struct BoardSize : IEquatable<BoardSize>
    {
        public int width;
        public int height;

        public BoardSize(int size)
        {
            width = size;
            height = size;
        }
        
        public BoardSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public BoardSize(Vector2Int size)
        {
            width = size.x;
            height = size.y;
        }

        public Vector2Int ToVector2Int() => new Vector2Int(width, height);
        
        public int? SquareSize => width == height ? width : null;

        // Common presets
        public static BoardSize Square3 => new BoardSize(3, 3);
        public static BoardSize Square4 => new BoardSize(4, 4);
        public static BoardSize Square5 => new BoardSize(5, 5);

        /// <summary> Index flattening helper: index = x + y * width </summary>
        public int ToIndex(BoardPosition pos) => pos.x + pos.y * width;

        /// <summary> Returns true if the given position is inside the board. </summary>
        public bool Contains(BoardPosition pos)
            => pos.x >= 0 && pos.y >= 0 && pos.x < width && pos.y < height;

        public bool Equals(BoardSize other)
            => width == other.width && height == other.height;

        public override bool Equals(object obj)
            => obj is BoardSize other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(width, height);

        public static bool operator ==(BoardSize a, BoardSize b) => a.Equals(b);
        public static bool operator !=(BoardSize a, BoardSize b) => !a.Equals(b);

        public override string ToString() => $"{width}x{height}";
    }
}