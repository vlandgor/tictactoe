using Runtime.UI.Game.Views;
using Runtime.UI.Menu.Views;
using Runtime.Utilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.UI
{
    [CreateAssetMenu(fileName = "ViewsFactory", menuName = "Playcbo/Factories/Views Factory", order = 0)]
    public class ViewsFactory : GenericFactory
    {
        [SerializeField] private MenuHudBaseView menuHudBaseView;
        [SerializeField] private MenuSettingsBaseView menuSettingsBaseView;
        [SerializeField] private MenuShopBaseView menuShopBaseView;
        [SerializeField] private MenuGameSetupBaseView menuGameSetupBaseView;
        
        [SerializeField] private GameHudBaseView gameHudBaseView;
        [SerializeField] private GameResultBaseView gameResultBaseView;
        
        public T Get<T>() where T : BaseView
        {
            if(typeof(T) == typeof(MenuHudBaseView))
            {
                return Get(menuHudBaseView) as T;
            }
            if(typeof(T) == typeof(MenuSettingsBaseView))
            {
                return Get(menuSettingsBaseView) as T;
            }
            if(typeof(T) == typeof(MenuShopBaseView))
            {
                return Get(menuShopBaseView) as T;
            }
            if(typeof(T) == typeof(MenuGameSetupBaseView))
            {
                return Get(menuGameSetupBaseView) as T;
            }
            
            if(typeof(T) == typeof(GameHudBaseView))
            {
                return Get(gameHudBaseView) as T;
            }
            if(typeof(T) == typeof(GameResultBaseView))
            {
                return Get(gameResultBaseView) as T;
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