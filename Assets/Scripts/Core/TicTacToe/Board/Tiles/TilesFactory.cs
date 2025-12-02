using Core.Utilities;
using UnityEngine;

namespace Core.TicTacToe.Board.Tiles
{
    [CreateAssetMenu(fileName = "TilesFactory", menuName = "Vlandgor/Factories/Tiles Factory", order = 0)]
    public class TilesFactory : GenericFactory
    {
        [SerializeField] private BoardTile _tilePrefab;
        
        public BoardTile Get()
        {
            return Get(_tilePrefab);
        }
        
        private T Get<T>(T prefab) where T : BoardTile
        {
            T instance = Instantiate(prefab);
            return instance;
        }
    }
}