using Runtime.GameBoard;
using Runtime.LoadingProvider;
using UnityEngine;

namespace Runtime.ConfigProvider
{
    public class ConfigProvider : MonoBehaviour, IConfigProvider
    {
        [SerializeField] private GameBoardConfig _gameBoardConfig;
        [SerializeField] private LoadingConfig _loadingConfig;
        
        public T GetConfig<T>() where T : ScriptableObject
        {
            if (typeof(T) == typeof(GameBoardConfig))
            {
                return _gameBoardConfig as T;
            }
            
            if (typeof(T) == typeof(LoadingConfig))
            {
                return _loadingConfig as T;
            }

            return null;
        }
    }
}