using Runtime.GamePlayer;
using Runtime.MatchService;

namespace Runtime.UI.Game
{
    public interface IGameMediator
    {
        public void UpdateTurnLabel(IPlayer player);
        public void ShowRoundResult(MatchType matchType, RoundResult roundResult);
        public void ShowSettings();
    }
}