using Cysharp.Threading.Tasks;
using Runtime.AudioService;
using Runtime.BotService;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.LoadingProvider;
using Runtime.Marks;
using Runtime.MatchService;
using UnityEngine;

namespace Runtime.UI.Menu.Models
{
    public class MenuGameSetupModel : Model
    {
        private ILoadingProvider _loadingProvider;
        private IMarksProvider _marksProvider;
        private IAudioService _audioService;
        private IConfigProvider _configProvider;
        
        private MatchMode _matchMode;
        
        private GameBoardConfig GameBoardConfig => _configProvider.GetConfig<GameBoardConfig>();
        
        public MenuGameSetupModel(
            ILoadingProvider loadingProvider, 
            IMarksProvider marksProvider, 
            IAudioService audioService,
            IConfigProvider configProvider)
        {
            _loadingProvider = loadingProvider;
            _marksProvider = marksProvider;
            _audioService = audioService;
            _configProvider = configProvider;
        }

        public void StartSetup(MatchMode matchMode)
        {
            _matchMode = matchMode;
        }
        
        public void StartGame(MatchType matchType, bool IsRanked)
        {
            IPlayer[] players = GetPlayers(matchType);
            MatchData matchData = new MatchData(matchType, _matchMode, players, IsRanked, GameBoardConfig.BoardSize);
            
            _loadingProvider.LoadGame(matchData).Forget();
        }
        
        private IPlayer[] GetPlayers(MatchType matchType)
        {
            IPlayer player1;
            IPlayer player2;
            
            switch (matchType)
            {
                case MatchType.PlayerVsPlayer:
                    player1 = new PersonPlayer(_marksProvider.GetRandomMarkSet().XMark,"Player 1");
                    player2 = new PersonPlayer(_marksProvider.GetRandomMarkSet().OMark,"Player 2");
                    return new []{player1, player2};
                case MatchType.PlayerVsComp:
                    player1 = new PersonPlayer(_marksProvider.GetRandomMarkSet().XMark,"Player 1");
                    player2 = new BotPlayer(_marksProvider.GetRandomMarkSet().OMark, BotLevel.Hard);
                    return new []{player1, player2};
                case MatchType.CompVsComp:
                    player1 = new BotPlayer(_marksProvider.GetRandomMarkSet().XMark, BotLevel.Easy);
                    player2 = new BotPlayer(_marksProvider.GetRandomMarkSet().OMark, BotLevel.Hard);
                    return new []{player1, player2};
            }

            return null;
        }
    }
}