using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.UI.Game.Presenters;
using Zenject;

namespace Runtime.UI.Game
{
    public class GameMediator : IGameMediator
    {
        private readonly LazyInject<GameHudPresenter> _hudPresenter;
        private readonly LazyInject<GameResultPresenter> _resultPresenter;

        public GameMediator(LazyInject<GameHudPresenter> hudPresenter, LazyInject<GameResultPresenter> settingsPresenter)
        {
            _hudPresenter = hudPresenter;
            _resultPresenter = settingsPresenter;
        }
        
        public void UpdateTurnLabel(IPlayer player)             => _hudPresenter.Value.UpdateTurnLabel(player);
        public void ShowGameResult(MatchResult matchResult)     => _resultPresenter.Value.ShowResult(matchResult);
    }
}