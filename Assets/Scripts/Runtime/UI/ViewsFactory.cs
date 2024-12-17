using Runtime.UI.BootAuthentication;
using Runtime.UI.GameHud;
using Runtime.UI.GameResult;
using Runtime.UI.MenuHud;
using Runtime.UI.MenuMatchSetup;
using Runtime.UI.MenuSettings;
using Runtime.UI.MenuShop;
using Runtime.Utilities;
using UnityEngine;

namespace Runtime.UI
{
    [CreateAssetMenu(fileName = "ViewsFactory", menuName = "Playcbo/Factories/Views Factory", order = 0)]
    public class ViewsFactory : GenericFactory
    {
        [Header("Boot Views")]
        [SerializeField] private BootAuthenticationView bootAuthenticationView;
        
        [Header("Menu Views")]
        [SerializeField] private MenuHudView menuHudView;
        [SerializeField] private MenuSettingsView menuSettingsView;
        [SerializeField] private MenuShopView menuShopView;
        [SerializeField] private MenuMatchSetupView menuMatchSetupView;
        
        [Header("Game Views")]
        [SerializeField] private GameHudView gameHudView;
        [SerializeField] private GameResultView gameResultView;
        
        public T Get<T>() where T : BaseView
        {
            // Boot Views
            if(typeof(T) == typeof(BootAuthenticationView))
            {
                return Get(bootAuthenticationView) as T;
            }
            
            // Menu Views
            if(typeof(T) == typeof(MenuHudView))
            {
                return Get(menuHudView) as T;
            }
            if(typeof(T) == typeof(MenuSettingsView))
            {
                return Get(menuSettingsView) as T;
            }
            if(typeof(T) == typeof(MenuShopView))
            {
                return Get(menuShopView) as T;
            }
            if(typeof(T) == typeof(MenuMatchSetupView))
            {
                return Get(menuMatchSetupView) as T;
            }
            
            // Game Views
            if(typeof(T) == typeof(GameHudView))
            {
                return Get(gameHudView) as T;
            }
            if(typeof(T) == typeof(GameResultView))
            {
                return Get(gameResultView) as T;
            }
            
            return null;
        }
        
        private T Get<T>(T prefab) where T : BaseView
        {
            T instance = Instantiate(prefab);
            MoveToFactoryScene(instance.gameObject);
            return instance;
        }
    }
}