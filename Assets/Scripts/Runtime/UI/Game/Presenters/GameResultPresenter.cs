using Runtime.MatchService;
using Runtime.UI.Game.Models;
using Runtime.UI.Game.Views;

namespace Runtime.UI.Game.Presenters
{
    public class GameResultPresenter : Presenter
    {
        private GameResultModel _model;
        private GameResultView _view;

        public GameResultPresenter(GameResultModel model, GameResultView view)
        {
            _model = model;
            _view = view;
        }

        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();

        public void ShowResult(MatchResult result)
        {
            if (result.Winner == null)
                _view.SetResultText("Draw!");
            else
                _view.SetResultText($"{result.Winner.Name} Won!");
            
            EnableView();
        }
        
        public async void LoadMenu()
        {
            _model.GoToMainMenu();
        }
    }
}