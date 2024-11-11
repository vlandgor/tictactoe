using UnityEngine;
using Zenject;

namespace Runtime.CameraService
{
    public class CameraServiceInstaller : MonoInstaller
    {
        [SerializeField] private CameraService _cameraServicePrefab;
        
        public override void InstallBindings()
        {
            BindCameraService();
        }

        private void BindCameraService()
        {
            Container
                .Bind<ICameraService>()
                .To<CameraService>()
                .FromComponentInNewPrefab(_cameraServicePrefab)
                .AsSingle();
        }
    }
}