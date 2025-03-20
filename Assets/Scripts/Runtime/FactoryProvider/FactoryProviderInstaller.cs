using UnityEngine;
using Zenject;

namespace Runtime.FactoryProvider
{
    public class FactoryProviderInstaller : MonoInstaller
    {
        [SerializeField] private FactoryProvider _factoryProviderPrefab;
        
        public override void InstallBindings()
        {
            BindFactoryProvider();
        }

        private void BindFactoryProvider()
        {
            FactoryProvider factoryProvider = Container
                .InstantiatePrefabForComponent<FactoryProvider>(_factoryProviderPrefab, Vector3.zero, Quaternion.identity, null);
            
            Container
                .Bind<FactoryProvider>()
                .FromInstance(factoryProvider)
                .AsSingle();
        }
    }
}