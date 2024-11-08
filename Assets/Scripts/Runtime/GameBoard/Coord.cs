using System;

namespace Runtime.GameBoard
{
    [Serializable]
    public struct Coord
    {
        public int x;
        public int y;
        
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public static bool operator ==(Coord a, Coord b)
        {
            return a.x == b.x && a.y == b.y;
        }
        
        public static bool operator !=(Coord a, Coord b)
        {
            return !(a == b);
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is Coord))
                return false;

            Coord coord = (Coord)obj;
            return this == coord;
        }
        
        public static readonly Coord Zero = new Coord(0, 0);
    }
}