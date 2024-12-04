using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.UI.Game.Presenters;
using Runtime.UI.Menu.Presenters;
using Zenject;

namespace Runtime.UI.Game
{
    public class GameMediator : IGameMediator
    {
        private readonly LazyInject<GameHudPresenter> _hudPresenter;
        private readonly LazyInject<GameResultPresenter> _resultPresenter;
        private readonly LazyInject<MenuSettingsPresenter> _settingsPresenter;

        public GameMediator(
            LazyInject<GameHudPresenter> hudPresenter, 
            LazyInject<GameResultPresenter> resultPresenter,
            LazyInject<MenuSettingsPresenter> settingsPresenter)
        {
            _hudPresenter = hudPresenter;
            _resultPresenter = resultPresenter;
            _settingsPresenter = settingsPresenter;
        }
        
        public void UpdateTurnLabel(IPlayer player)             => _hudPresenter.Value.UpdateTurnLabel(player);
        public void ShowGameResult(MatchResult matchResult)     => _resultPresenter.Value.ShowResult(matchResult);
        public void ShowSettings()                              => _settingsPresenter.Value.EnableView();
    }
}