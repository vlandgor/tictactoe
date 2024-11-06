using UnityEngine;
using Zenject;

namespace Runtime.ConfigProvider
{
    public class ConfigProviderInstaller : MonoInstaller
    {
        [SerializeField] private ConfigProvider _configProviderPrefab;
        
        public override void InstallBindings()
        {
            BindConfigProvider();
        }
        
        private void BindConfigProvider()
        {
            ConfigProvider configProvider = Container
                .InstantiatePrefabForComponent<ConfigProvider>(_configProviderPrefab, Vector3.zero, Quaternion.identity, null);

            Container
                .Bind<IConfigProvider>()
                .FromInstance(configProvider)
                .AsSingle();
        }
    }
}