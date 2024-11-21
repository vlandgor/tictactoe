using UnityEngine;

namespace Runtime.AudioService
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioProvider _audioProvider;
        
        public void PlayButtonClickFX()
        {
            _audioSource.PlayOneShot(_audioProvider.GetButtonClickFX());
        }
    }
}