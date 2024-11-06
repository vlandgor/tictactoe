using UnityEngine;
using Zenject;

namespace Runtime.InputService
{
    public class InputServiceInstaller : MonoInstaller
    {
        [SerializeField] private InputService _inputServicePrefab;
        
        public override void InstallBindings()
        {
            BindInputService();
        }
        
        private void BindInputService()
        {
            InputService inputService = Container
                .InstantiatePrefabForComponent<InputService>(_inputServicePrefab, Vector3.zero, Quaternion.identity, null);

            Container
                .Bind<IInputService>()
                .FromInstance(inputService)
                .AsSingle();
        }
    }
}