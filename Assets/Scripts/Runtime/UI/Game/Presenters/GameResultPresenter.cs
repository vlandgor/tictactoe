using System;
using Runtime.MatchService;
using Runtime.UI.Game.Models;
using Runtime.UI.Game.Views;

namespace Runtime.UI.Game.Presenters
{
    public class GameResultPresenter : Presenter, IDisposable
    {
        private GameResultModel _model;
        private GameResultView _view;
        
        private IGameMediator _gameMediator;

        public GameResultPresenter(GameResultModel model, GameResultView view, IGameMediator gameMediator)
        {
            _model = model;
            _view = view;
            
            SubscribeToViewEvents();
        }

        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();

        public void ShowResult(MatchResult result)
        {
            if (result.Winner == null)
                _view.ShowDraw();
            else
                _view.ShowWinner(result.Winner.Name);
            
            EnableView();
        }

        private void SubscribeToViewEvents()
        {
            _view.OnHomeButtonClicked += HandleHomeButtonClicked;
            _view.OnRestartButtonClicked += HandleRestartButtonClicked;
            _view.OnContinueButtonClicked += HandleContinueButtonClicked;
        }
        private void UnsubscribeFromViewEvents()
        {
            _view.OnHomeButtonClicked -= HandleHomeButtonClicked;
            _view.OnRestartButtonClicked -= HandleRestartButtonClicked;
            _view.OnContinueButtonClicked -= HandleContinueButtonClicked;
        }
        
        private void HandleHomeButtonClicked()
        {
            _model.LoadMenu();
        }
        
        private void HandleRestartButtonClicked()
        {
            _model.RestartMatch();
        }
        
        private void HandleContinueButtonClicked()
        {
            _model.LoadMenu();
        }
        
        public void Dispose()
        {
            UnsubscribeFromViewEvents();
        }
    }
}