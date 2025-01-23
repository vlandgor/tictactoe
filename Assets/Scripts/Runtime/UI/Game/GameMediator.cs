using Runtime.GamePlayer;
using Runtime.UI.GameHud;
using Runtime.UI.MenuSettings;
using Zenject;

namespace Runtime.UI.Game
{
    public class GameMediator : IGameMediator
    {
        private readonly LazyInject<GameHudPresenter> _hudPresenter;
        private readonly LazyInject<MenuSettingsPresenter> _settingsPresenter;

        public GameMediator(
            LazyInject<GameHudPresenter> hudPresenter, 
            LazyInject<MenuSettingsPresenter> settingsPresenter)
        {
            _hudPresenter = hudPresenter;
            _settingsPresenter = settingsPresenter;
        }
        
        public void UpdateTurnLabel(IPlayer player)             => _hudPresenter.Value.UpdateTurnLabel(player);
        public void ShowSettings()                              => _settingsPresenter.Value.EnableView();
    }
}