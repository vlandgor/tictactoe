using Cysharp.Threading.Tasks;
using Runtime.BotService;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.InputService;
using Runtime.UI.Game;

namespace Runtime.MatchService
{
    public interface IMatchService
    {
        public UniTask Initialize(MatchData matchData);
        public UniTask Restart();
    }
    
    public interface ILocalMatchService : IMatchService
    {
        public IGameBoard GameBoard { get; }
        public IInputService InputService { get; }
        public IBotService BotService { get; }
        public IConfigProvider ConfigProvider { get; }
        public IGameMediator GameMediator { get; }
        public MatchData MatchData { get; }
        public Match Match { get; }
        
        public void ChangeState(IMatchState state);
        public void ChangeTurn();
        public IPlayer GetOpponent(IPlayer player);
    }
}