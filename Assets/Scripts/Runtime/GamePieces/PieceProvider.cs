using UnityEngine;

namespace Runtime.GamePieces
{
    public class PieceProvider : MonoBehaviour, IPieceProvider
    {
        [SerializeField] private PiecesStorage storage;
        
        public PieceSet GetPieceSet(int index)
        {
            PieceSet set = storage.GetSet(index);
            return set;
        }
        
        public PieceSet GetRandomPieceSet()
        {
            PieceSet set = storage.GetRandomSet();
            return set;
        }

        public Piece GetPiece(int index, PieceType type)
        {
            PieceSet set = storage.GetSet(index);
            return set.GetPiece(type);
        }
    }
}