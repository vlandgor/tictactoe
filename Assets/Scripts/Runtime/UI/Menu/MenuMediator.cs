using Runtime.UI.Menu.Presenters;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MenuMediator : IMenuMediator
    {
        private readonly LazyInject<MenuHudPresenter> _hudPresenter;
        private readonly LazyInject<MenuSettingsPresenter> _settingsPresenter;
        private readonly LazyInject<MenuShopPresenter> _shopPresenter;
        private readonly LazyInject<MenuCreateGamePresenter> _createGamePresenter;

        public MenuMediator(
            LazyInject<MenuHudPresenter> hudPresenter, 
            LazyInject<MenuSettingsPresenter> settingsPresenter,
            LazyInject<MenuShopPresenter> shopPresenter,
            LazyInject<MenuCreateGamePresenter> createGamePresenter)
        {
            _hudPresenter = hudPresenter;
            _settingsPresenter = settingsPresenter;
            _shopPresenter = shopPresenter;
            _createGamePresenter = createGamePresenter;
        }

        public void ShowShop() => _shopPresenter.Value.EnableView();
        public void ShowSettings() => _settingsPresenter.Value.EnableView();
        public void ShowCreateGame() => _createGamePresenter.Value.EnableView();
    }
}