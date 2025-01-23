using Runtime.LoadingProvider;
using UnityEngine;

namespace Runtime.ConfigProvider
{
    public class ConfigProvider : MonoBehaviour, IConfigProvider
    {
        [SerializeField] private LoadingConfig _loadingConfig;
        
        public T GetConfig<T>() where T : ScriptableObject
        {
            if (typeof(T) == typeof(LoadingConfig))
            {
                return _loadingConfig as T;
            }

            return null;
        }
    }
}