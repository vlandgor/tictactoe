using Runtime.MatchService;
using Runtime.UI.Menu.Presenters;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MenuMediator : IMenuMediator
    {
        private readonly LazyInject<MenuHudBasePresenter> _hudPresenter;
        private readonly LazyInject<MenuSettingsBasePresenter> _settingsPresenter;
        private readonly LazyInject<MenuShopBasePresenter> _shopPresenter;
        private readonly LazyInject<MenuGameSetupBasePresenter> _gameSetupPresenter;

        public MenuMediator(
            LazyInject<MenuHudBasePresenter> hudPresenter, 
            LazyInject<MenuSettingsBasePresenter> settingsPresenter,
            LazyInject<MenuShopBasePresenter> shopPresenter,
            LazyInject<MenuGameSetupBasePresenter> gameSetupPresenter)
        {
            _hudPresenter = hudPresenter;
            _settingsPresenter = settingsPresenter;
            _shopPresenter = shopPresenter;
            _gameSetupPresenter = gameSetupPresenter;
        }

        public void ShowShop() => _shopPresenter.Value.EnableView();
        public void ShowSettings() => _settingsPresenter.Value.EnableView();
        public void ShowGameSetup(MatchMode matchMode) => _gameSetupPresenter.Value.StartSetup(matchMode);
    }
}