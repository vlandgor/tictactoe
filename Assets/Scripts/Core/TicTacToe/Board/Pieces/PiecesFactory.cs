using Core.Utilities;
using UnityEngine;

namespace Core.TicTacToe.Board.Pieces
{
    [CreateAssetMenu(fileName = "PiecesFactory", menuName = "Vlandgor/Factories/Pieces Factory", order = 0)]
    public class PiecesFactory : GenericFactory
    {
        [SerializeField] private BoardPiece _crossPiece;
        [SerializeField] private BoardPiece _circlePiece;
        
        public BoardPiece Get(PieceType pieceType)
        {
            BoardPiece instance = Instantiate(pieceType == PieceType.Cross ? _crossPiece : _circlePiece);
            return instance;
        }
    }
}