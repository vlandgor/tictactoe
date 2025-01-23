using Runtime.Utilities;
using UnityEngine;

namespace Runtime.GamePieces.Local
{
    [CreateAssetMenu(fileName = "PiecesFactory", menuName = "Playcbo/Factories/Pieces Factory", order = 0)]
    public class LocalPiecesFactory : GenericFactory, IPiecesFactory
    {
        public T Get<T>(T prefab) where T : Piece
        {
            T instance = Instantiate(prefab);
            MoveToFactoryScene(instance.gameObject);
            return instance;
        }
    }
}