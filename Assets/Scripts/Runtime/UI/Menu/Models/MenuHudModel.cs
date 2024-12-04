using Runtime.AudioService;
using Runtime.MatchService;
using UnityEngine;
using System;

namespace Runtime.UI.Menu.Models
{
    public class MenuHudModel
    {
        private readonly IAudioService _audioService;
        
        private readonly GameMode[] _gameModes;
        private int _currentGameModeIndex;

        public GameMode CurrentGameMode => _gameModes[_currentGameModeIndex];

        public MenuHudModel(IAudioService audioService)
        {
            _audioService = audioService ?? throw new ArgumentNullException(nameof(audioService));
            _gameModes = (GameMode[])Enum.GetValues(typeof(GameMode)); // Cache enum values
            _currentGameModeIndex = 0;
        }

        public void PrevGameMode()
        {
            _audioService.PlayButtonClickFX();

            _currentGameModeIndex--;

            if (_currentGameModeIndex < 0)
            {
                _currentGameModeIndex = _gameModes.Length - 1;
            }
        }

        public void NextGameMode()
        {
            _audioService.PlayButtonClickFX();

            _currentGameModeIndex++;

            if (_currentGameModeIndex >= _gameModes.Length)
            {
                _currentGameModeIndex = 0;
            }
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