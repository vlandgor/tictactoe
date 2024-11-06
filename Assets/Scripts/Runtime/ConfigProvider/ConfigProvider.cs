using Runtime.GameBoard;
using UnityEngine;

namespace Runtime.ConfigProvider
{
    public class ConfigProvider : MonoBehaviour, IConfigProvider
    {
        [SerializeField] private GameBoardConfig _gameBoardConfig;
        
        public T GetConfig<T>() where T : ScriptableObject
        {
            if (typeof(T) == typeof(GameBoardConfig))
            {
                return _gameBoardConfig as T;
            }

            return null;
        }
    }
}