using Runtime.UI.Menu.Presenters;
using Zenject;

namespace Runtime.UI.Menu
{
    public class MenuMediator : IMenuMediator
    {
        private readonly LazyInject<MenuHudPresenter> _hudPresenter;
        private readonly LazyInject<MenuSettingsPresenter> _settingsPresenter;

        public MenuMediator(LazyInject<MenuHudPresenter> hudPresenter, LazyInject<MenuSettingsPresenter> settingsPresenter)
        {
            _hudPresenter = hudPresenter;
            _settingsPresenter = settingsPresenter;
        }

        public void ShowSettings() => _settingsPresenter.Value.EnableView();
    }
}