using Cysharp.Threading.Tasks;
using Runtime.AudioService;
using Runtime.BotService;
using Runtime.GamePlayer;
using Runtime.LoadingProvider;
using Runtime.Marks;
using Runtime.MatchService;

namespace Runtime.UI.Menu.Models
{
    public class MenuGameSetupModel : Model
    {
        private ILoadingProvider _loadingProvider;
        private IMarksProvider _marksProvider;
        private IAudioService _audioService;
        
        public MenuGameSetupModel(ILoadingProvider loadingProvider, IMarksProvider marksProvider, IAudioService audioService)
        {
            _loadingProvider = loadingProvider;
            _marksProvider = marksProvider;
            _audioService = audioService;
        }
        
        public void StartGame(GameMode gameMode)
        {
            (IPlayer, IPlayer) players = GetPlayers(gameMode);
            MatchData matchData = new MatchData(gameMode, players.Item1, players.Item2);
            
            _loadingProvider.LoadGame(matchData).Forget();
        }
        
        private (IPlayer, IPlayer) GetPlayers(GameMode gameMode)
        {
            IPlayer player1;
            IPlayer player2;
            
            switch (gameMode)
            {
                case GameMode.PlayerVsPlayer:
                    player1 = new PersonPlayer(_marksProvider.GetRandomMarkSet().XMark,"Player 1");
                    player2 = new PersonPlayer(_marksProvider.GetRandomMarkSet().OMark,"Player 2");
                    return (player1, player2);
                case GameMode.PlayerVsComp:
                    player1 = new PersonPlayer(_marksProvider.GetRandomMarkSet().XMark,"Player 1");
                    player2 = new BotPlayer(_marksProvider.GetRandomMarkSet().OMark, BotLevel.Hard);
                    return (player1, player2);
                case GameMode.CompVsComp:
                    player1 = new BotPlayer(_marksProvider.GetRandomMarkSet().XMark, BotLevel.Easy);
                    player2 = new BotPlayer(_marksProvider.GetRandomMarkSet().OMark, BotLevel.Hard);
                    return (player1, player2);
            }
                
            return (null, null);
        }
    }
}