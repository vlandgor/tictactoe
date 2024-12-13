using Runtime.UI.Game.Views;
using Runtime.UI.Menu.Views;
using Runtime.Utilities;
using UnityEngine;

namespace Runtime.UI
{
    [CreateAssetMenu(fileName = "ViewsFactory", menuName = "Playcbo/Factories/Views Factory", order = 0)]
    public class ViewsFactory : GenericFactory
    {
        [SerializeField] private MenuHudView _menuHudView;
        [SerializeField] private MenuSettingsView _menuSettingsView;
        [SerializeField] private MenuShopView _menuShopView;
        [SerializeField] private MenuGameSetupView _menuGameSetupView;
        
        [SerializeField] private GameHudView _gameHudView;
        [SerializeField] private GameResultView _gameResultView;
        
        public T Get<T>() where T : View
        {
            if(typeof(T) == typeof(MenuHudView))
            {
                return Get(_menuHudView) as T;
            }
            if(typeof(T) == typeof(MenuSettingsView))
            {
                return Get(_menuSettingsView) as T;
            }
            if(typeof(T) == typeof(MenuShopView))
            {
                return Get(_menuShopView) as T;
            }
            if(typeof(T) == typeof(MenuGameSetupView))
            {
                return Get(_menuGameSetupView) as T;
            }
            
            if(typeof(T) == typeof(GameHudView))
            {
                return Get(_gameHudView) as T;
            }
            if(typeof(T) == typeof(GameResultView))
            {
                return Get(_gameResultView) as T;
            }
            
            return null;
        }
        
        private T Get<T>(T prefab) where T : View
        {
            T instance = Instantiate(prefab);
            MoveToFactoryScene(instance.gameObject);
            return instance;
        }
    }
}