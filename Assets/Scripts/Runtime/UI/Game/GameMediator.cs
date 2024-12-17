using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.UI.Game.Presenters;
using Runtime.UI.Menu.Presenters;
using Zenject;

namespace Runtime.UI.Game
{
    public class GameMediator : IGameMediator
    {
        private readonly LazyInject<GameHudBasePresenter> _hudPresenter;
        private readonly LazyInject<GameResultBasePresenter> _resultPresenter;
        private readonly LazyInject<MenuSettingsBasePresenter> _settingsPresenter;

        public GameMediator(
            LazyInject<GameHudBasePresenter> hudPresenter, 
            LazyInject<GameResultBasePresenter> resultPresenter,
            LazyInject<MenuSettingsBasePresenter> settingsPresenter)
        {
            _hudPresenter = hudPresenter;
            _resultPresenter = resultPresenter;
            _settingsPresenter = settingsPresenter;
        }
        
        public void UpdateTurnLabel(IPlayer player)             => _hudPresenter.Value.UpdateTurnLabel(player);
        public void ShowRoundResult(MatchType matchType, RoundResult matchResult)     => _resultPresenter.Value.ShowResult(matchType, matchResult);
        public void ShowSettings()                              => _settingsPresenter.Value.EnableView();
    }
}