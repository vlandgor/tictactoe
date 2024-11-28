using System;

namespace Runtime.GameBoard
{
    [Serializable]
    public struct Crd
    {
        public bool Equals(Crd other)
        {
            return x == other.x && y == other.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public int x;
        public int y;
        
        public Crd(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public static bool operator ==(Crd a, Crd b)
        {
            return a.x == b.x && a.y == b.y;
        }
        
        public static bool operator !=(Crd a, Crd b)
        {
            return !(a == b);
        }
        
        public override bool Equals(object obj)
        {
            if (!(obj is Crd))
                return false;

            Crd crd = (Crd)obj;
            return this == crd;
        }
        
        public static readonly Crd Zero = new Crd(0, 0);
    }
}