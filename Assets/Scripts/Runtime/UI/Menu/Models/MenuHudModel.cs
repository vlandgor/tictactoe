using Runtime.AudioService;
using UnityEngine;

namespace Runtime.UI.Menu.Models
{
    public class MenuHudModel
    {
        private IAudioService _audioService;
        
        public MenuHudModel(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void EnableSettings()
        {
            _audioService.PlayButtonClickFX();
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}