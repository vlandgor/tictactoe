using Runtime.Utilities;
using UnityEngine;

namespace Runtime.GamePieces
{
    [CreateAssetMenu(fileName = "LocalPiecesFactory", menuName = "Playcbo/Factories/Local Pieces Factory", order = 0)]
    public class PiecesFactory : GenericFactory, IPiecesFactory
    {
        public T Get<T>(T prefab) where T : Piece
        {
            T instance = Instantiate(prefab);
            return instance;
        }
    }
}