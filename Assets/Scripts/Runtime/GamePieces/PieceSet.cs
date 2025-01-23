using System;
using System.Linq;

namespace Runtime.GamePieces
{
    [Serializable]
    public class PieceSet
    {
        public Piece[] pieces = new Piece[2];

        public Piece GetPiece(PieceType type)
        {
            Piece piece = pieces.FirstOrDefault(p => p.PieceType == type);
            return piece;
        }
    }
}