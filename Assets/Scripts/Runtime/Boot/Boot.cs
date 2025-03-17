using Runtime.LoadingProvider;
using Runtime.Logger;
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
            DLogger.Message(DSenders.Application).WithText("App started").WithFormat(DFormat.Normal).Log();
            
            await _loadingProvider.LoadApp();
        }
    }
}