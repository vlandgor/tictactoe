using Runtime.GamePlayer;

namespace Runtime.UI.Game
{
    public interface IGameMediator
    {
        public void UpdateTurnLabel(IPlayer player);
        public void ShowSettings();
    }
}