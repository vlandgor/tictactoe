using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.BoardManager.Local
{
    [Serializable]
    public struct BoardPosition : IEquatable<BoardPosition>
    {
        public int x;
        [FormerlySerializedAs("Y")] public int y;

        public BoardPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Convenience constructor for Vector2Int
        public BoardPosition(Vector2Int position)
        {
            x = position.x;
            y = position.y;
        }

        // Convert to Vector2Int easily
        public Vector2Int ToVector2Int() => new Vector2Int(x, y);

        // Zero position (0,0)
        public static BoardPosition Zero => new BoardPosition(0, 0);

        // Directions (useful for neighbor checks)
        public static readonly BoardPosition Up = new BoardPosition(0, 1);
        public static readonly BoardPosition Down = new BoardPosition(0, -1);
        public static readonly BoardPosition Left = new BoardPosition(-1, 0);
        public static readonly BoardPosition Right = new BoardPosition(1, 0);

        // Operator overloads
        public static BoardPosition operator +(BoardPosition a, BoardPosition b) =>
            new BoardPosition(a.x + b.x, a.y + b.y);

        public static BoardPosition operator -(BoardPosition a, BoardPosition b) =>
            new BoardPosition(a.x - b.x, a.y - b.y);

        public static BoardPosition operator *(BoardPosition a, int scalar) =>
            new BoardPosition(a.x * scalar, a.y * scalar);

        public static bool operator ==(BoardPosition a, BoardPosition b) =>
            a.Equals(b);

        public static bool operator !=(BoardPosition a, BoardPosition b) =>
            !a.Equals(b);

        // Implement IEquatable for efficiency
        public bool Equals(BoardPosition other) =>
            x == other.x && y == other.y;

        public override bool Equals(object obj) =>
            obj is BoardPosition other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(x, y);

        // Useful for debugging and logs
        public override string ToString() => $"[{x}, {y}]";

        // Quick way to check adjacency
        public bool IsAdjacent(BoardPosition other)
        {
            int dx = Mathf.Abs(x - other.x);
            int dy = Mathf.Abs(y - other.y);
            return (dx + dy) == 1;
        }

        // Calculate Manhattan distance (useful in grid-based games)
        public int ManhattanDistance(BoardPosition other) =>
            Mathf.Abs(x - other.x) + Mathf.Abs(y - other.y);
    }
}
