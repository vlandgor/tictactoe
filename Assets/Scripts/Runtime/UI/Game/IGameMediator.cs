using Runtime.GamePlayer;
using Runtime.MatchService;

namespace Runtime.UI.Game
{
    public interface IGameMediator
    {
        public void UpdateTurnLabel(IPlayer player);
        public void ShowGameResult(MatchResult matchResult);
    }
}