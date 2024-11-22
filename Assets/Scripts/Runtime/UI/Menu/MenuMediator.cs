using Runtime.UI.Menu.Presenters;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MenuMediator : IMenuMediator
    {
        private readonly LazyInject<MenuHudPresenter> _hudPresenter;
        private readonly LazyInject<MenuSettingsPresenter> _settingsPresenter;
        private readonly LazyInject<MenuShopPresenter> _shopPresenter;

        public MenuMediator(
            LazyInject<MenuHudPresenter> hudPresenter, 
            LazyInject<MenuSettingsPresenter> settingsPresenter,
            LazyInject<MenuShopPresenter> shopPresenter)
        {
            _hudPresenter = hudPresenter;
            _settingsPresenter = settingsPresenter;
            _shopPresenter = shopPresenter;
        }

        public void ShowShop() => _shopPresenter.Value.EnableView();
        public void ShowSettings() => _settingsPresenter.Value.EnableView();
    }
}