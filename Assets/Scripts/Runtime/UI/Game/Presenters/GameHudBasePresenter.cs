using Runtime.GamePlayer;
using Runtime.UI.Game.Models;
using Runtime.UI.Game.Views;

namespace Runtime.UI.Game.Presenters
{
    public class GameHudBasePresenter : BasePresenter
    {
        private GameHudBaseModel _baseModel;
        private GameHudBaseView _baseView;

        public GameHudBasePresenter(GameHudBaseModel baseModel, GameHudBaseView baseView)
        {
            _baseModel = baseModel;
            
            _baseView = baseView;
        }

        public override void EnableView() => _baseView.Show();
        public override void DisableView() => _baseView.Hide();

        public void UpdateTurnLabel(IPlayer player)
        {
            _baseView.UpdateTurnLabel(player.Name);
        }
    }
}