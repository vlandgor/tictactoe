using UnityEngine;
using Zenject;

namespace Runtime.LoadingProvider
{
    public class LoadingProviderInstaller : MonoInstaller
    {
        [SerializeField] private LoadingCurtain _loadingCurtainPrefab;
        
        public override void InstallBindings()
        {
            BindLoadingCurtain();
            BindLoadingProvider();
        }

        private void BindLoadingCurtain()
        {
            Container
                .Bind<ILoadingCurtain>()
                .To<LoadingCurtain>()
                .FromComponentInNewPrefab(_loadingCurtainPrefab)
                .AsSingle();
        }

        private void BindLoadingProvider()
        {
            Container
                .Bind<ILoadingProvider>()
                .To<LoadingProvider>()
                .AsSingle();
        }
    }
}