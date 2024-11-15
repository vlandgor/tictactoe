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
            CameraService gameBoard = Container
                .InstantiatePrefabForComponent<CameraService>(_cameraServicePrefab, Vector3.zero, Quaternion.identity, null);
            
            Container
                .Bind<ICameraService>()
                .To<CameraService>()
                .FromInstance(_cameraServicePrefab)
                .AsSingle();
        }
    }
}