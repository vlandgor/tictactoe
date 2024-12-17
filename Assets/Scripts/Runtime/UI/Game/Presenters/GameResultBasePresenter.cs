using Runtime.GamePlayer;
using Runtime.MatchService;
using Runtime.UI.Game.Models;
using Runtime.UI.Game.Views;

namespace Runtime.UI.Game.Presenters
{
    public class GameResultBasePresenter : BasePresenter
    {
        private IGameMediator _gameMediator;
        private GameResultBaseModel _baseModel;
        private GameResultBaseView _baseView;

        public GameResultBasePresenter(IGameMediator gameMediator, GameResultBaseModel baseModel, GameResultBaseView baseView)
        {
            _gameMediator = gameMediator;
            _baseModel = baseModel;
            _baseView = baseView;
        }

        public override void EnableView() => _baseView.Show();
        public override void DisableView() => _baseView.Hide();

        public void ShowResult(MatchType matchType, RoundResult result)
        {
            if(result.Winner == null)
                _baseView.ShowDraw();
            else
            {
                switch (matchType)
                {
                    case MatchType.PlayerVsComp:
                        if (result.Winner is PersonPlayer)
                            _baseView.ShowYouWon();
                        else
                            _baseView.ShowYouLost();
                        break;
                    case MatchType.PlayerVsPlayer:
                        _baseView.ShowPlayerWon(result.Winner.Name);
                        break;
                    case MatchType.CompVsComp:
                        _baseView.ShowPlayerWon(result.Winner.Name);
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
            _baseModel.RestartMatch();
            _baseView.Hide();
        }
        
        public void LeaveButtonPressed()
        {
            _baseModel.LoadMenu();
        }
    }
}