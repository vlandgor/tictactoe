using UnityEngine;
using Zenject;

namespace Runtime.AudioService
{
    public class AudioServiceInstaller : MonoInstaller
    {
        [SerializeField] private AudioService _audioServicePrefab;
        
        public override void InstallBindings()
        {
            BindAudioService();
        }

        private void BindAudioService()
        {
            AudioService audioService = Container
                .InstantiatePrefabForComponent<AudioService>(_audioServicePrefab, Vector3.zero, Quaternion.identity, null);

            Container
                .Bind<IAudioService>()
                .FromInstance(audioService)
                .AsSingle();
        }
    }
}