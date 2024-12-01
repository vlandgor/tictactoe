using Runtime.UI.Menu.Presenters;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MenuMediator : IMenuMediator
    {
        private readonly LazyInject<MenuHudPresenter> _hudPresenter;
        private readonly LazyInject<MenuSettingsPresenter> _settingsPresenter;
        private readonly LazyInject<MenuShopPresenter> _shopPresenter;
        private readonly LazyInject<MenuGameSetupPresenter> _gameSetupPresenter;

        public MenuMediator(
            LazyInject<MenuHudPresenter> hudPresenter, 
            LazyInject<MenuSettingsPresenter> settingsPresenter,
            LazyInject<MenuShopPresenter> shopPresenter,
            LazyInject<MenuGameSetupPresenter> gameSetupPresenter)
        {
            _hudPresenter = hudPresenter;
            _settingsPresenter = settingsPresenter;
            _shopPresenter = shopPresenter;
            _gameSetupPresenter = gameSetupPresenter;
        }

        public void ShowShop() => _shopPresenter.Value.EnableView();
        public void ShowSettings() => _settingsPresenter.Value.EnableView();
        public void ShowGameSetup() => _gameSetupPresenter.Value.EnableView();
    }
}