using UnityEngine;

namespace Runtime.AudioService
{
    [CreateAssetMenu(fileName = "AudioProvider", menuName = "Playcbo/Storages/Audio Storage", order = 0)]
    public class AudioProvider : ScriptableObject
    {
        [SerializeField] private AudioClip _buttonClickFX;
        
        
        public AudioClip GetButtonClickFX()
        {
            return _buttonClickFX;
        }
    }
}