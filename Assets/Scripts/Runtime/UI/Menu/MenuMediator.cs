using Runtime.MatchService;
using Runtime.UI.MenuHud;
using Runtime.UI.MenuMatchSetup;
using Runtime.UI.MenuSettings;
using Runtime.UI.MenuShop;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MenuMediator : IMenuMediator
    {
        private readonly LazyInject<MenuHudPresenter> _hudPresenter;
        private readonly LazyInject<MenuSettingsPresenter> _settingsPresenter;
        private readonly LazyInject<MenuShopPresenter> _shopPresenter;
        private readonly LazyInject<MenuMatchSetupPresenter> _matchSetupPresenter;

        public MenuMediator(
            LazyInject<MenuHudPresenter> hudPresenter, 
            LazyInject<MenuSettingsPresenter> settingsPresenter,
            LazyInject<MenuShopPresenter> shopPresenter,
            LazyInject<MenuMatchSetupPresenter> matchSetupPresenter)
        {
            _hudPresenter = hudPresenter;
            _settingsPresenter = settingsPresenter;
            _shopPresenter = shopPresenter;
            _matchSetupPresenter = matchSetupPresenter;
        }

        public void ShowShop() => _shopPresenter.Value.EnableView();
        public void ShowSettings() => _settingsPresenter.Value.EnableView();
        public void ShowGameSetup(MatchMode matchMode) => _matchSetupPresenter.Value.StartSetup(matchMode);
    }
}