using Runtime.GamePlayer;
using Runtime.UI.Game.Models;
using Runtime.UI.Game.Views;

namespace Runtime.UI.Game.Presenters
{
    public class GameHudPresenter : Presenter
    {
        private GameHudModel _model;
        private GameHudView _view;

        public GameHudPresenter(GameHudModel model, GameHudView view)
        {
            _model = model;
            
            _view = view;
        }

        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();

        public void UpdateTurnLabel(IPlayer player)
        {
            _view.UpdateTurnLabel(player.Name);
        }
    }
}