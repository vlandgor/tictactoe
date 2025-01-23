using UnityEngine;

namespace Runtime.GamePieces
{
    public class Piece : MonoBehaviour
    {
        [SerializeField] private PieceType type;
        public PieceType PieceType => type;
    }
}