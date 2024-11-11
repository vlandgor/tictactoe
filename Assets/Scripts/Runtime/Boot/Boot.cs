using Runtime.LoadingProvider;
using UnityEngine;
using Zenject;

namespace Runtime.Boot
{
    public class Boot : MonoBehaviour
    {
        private ILoadingProvider _loadingProvider;
        
        [Inject]
        public void Construct(ILoadingProvider loadingProvider)
        {
            _loadingProvider = loadingProvider;
        }

        private async void Start()
        {
            await _loadingProvider.LoadMenu();
        }
    }
}