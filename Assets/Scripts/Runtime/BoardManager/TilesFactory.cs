using Runtime.GameModes.ClassicMode.Board;
using Runtime.Utilities;
using UnityEngine;

namespace Runtime.BoardManager
{
    [CreateAssetMenu(fileName = "LocalTilesFactory", menuName = "Playcbo/Factories/Local Tiles Factory", order = 0)]
    public class TilesFactory : GenericFactory, ITilesFactory
    {
        [SerializeField] private ClassicBoardTile classicTilePrefab;
        
        public T Get<T>() where T : BoardTile
        {
            if(typeof(T) == typeof(ClassicBoardTile))
            {
                return Get(classicTilePrefab) as T;
            }
            
            return null;
        }
        
        private T Get<T>(T prefab) where T : BoardTile
        {
            T instance = Instantiate(prefab);
            return instance;
        }
    }
}