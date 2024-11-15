using Runtime.GamePlayer;
using Runtime.UI.GameHud.Models;
using Runtime.UI.GameHud.Views;

namespace Runtime.UI.GameHud.Presenters
{
    public class GameHudPresenter
    {
        private GameHudModel _model;
        private GameHudView _view;

        public GameHudPresenter(GameHudModel model, GameHudView view)
        {
            _model = model;
            _view = view;
        }
        
        public void UpdateTurnLabel(IPlayer player)
        {
            _view.UpdateTurnLabel(player.Name);
        }
    }
}