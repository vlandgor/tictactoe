using Cysharp.Threading.Tasks;
using Runtime.UI.Screens;
using UnityEngine;

namespace Runtime.UI
{
    public class UIScreenFactory : MonoBehaviour, IUIScreenFactory
    {
        [SerializeField] private MainMenuScreen _mainMenuScreen;
        [SerializeField] private GameHudScreen _gameHudScreen;
        
        public async UniTask<T> GetScreen<T>() where T : ScreenUI
        {
            if (typeof(T) == typeof(MainMenuScreen))
            {
                return _mainMenuScreen as T;
            }
            
            if (typeof(T) == typeof(GameHudScreen))
            {
                return _gameHudScreen as T;
            }

            return null;
        }
    }
}