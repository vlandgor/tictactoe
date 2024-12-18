﻿using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.UI.Game;

namespace Runtime.UI.GameResult
{
    public class GameResultPresenter : BasePresenter
    {
        private IGameMediator _gameMediator;
        private GameResultModel _model;
        private GameResultView _view;

        public GameResultPresenter(IGameMediator gameMediator, GameResultModel model, GameResultView view)
        {
            _gameMediator = gameMediator;
            _model = model;
            _view = view;
        }

        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();

        public void ShowResult(MatchType matchType, RoundResult result)
        {
            if(result.Winner == null)
                _view.ShowDraw();
            else
            {
                switch (matchType)
                {
                    case MatchType.PlayerVsComp:
                        if (result.Winner is PersonPlayer)
                            _view.ShowYouWon();
                        else
                            _view.ShowYouLost();
                        break;
                    case MatchType.PlayerVsPlayer:
                        _view.ShowPlayerWon(result.Winner.Name);
                        break;
                    case MatchType.CompVsComp:
                        _view.ShowPlayerWon(result.Winner.Name);
                        break;
                }
            }
            
            EnableView();
        }
        
        public void SettingsButtonPressed()
        {
            _gameMediator.ShowSettings();
        }
        
        public void RestartButtonPressed()
        {
            _model.RestartMatch();
            _view.Hide();
        }
        
        public void LeaveButtonPressed()
        {
            _model.LoadMenu();
        }
    }
}