using Cysharp.Threading.Tasks;
using Runtime.AudioService;
using Runtime.BotService;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using Runtime.LoadingProvider;
using Runtime.MatchService;
using Runtime.Tokens;
using UnityEngine;

namespace Runtime.UI.Menu.Models
{
    public class MenuGameSetupModel : Model
    {
        private ILoadingProvider _loadingProvider;
        private ITokensProvider _tokensProvider;
        private IAudioService _audioService;
        private IConfigProvider _configProvider;
        
        private MatchMode _matchMode;
        
        private GameBoardConfig GameBoardConfig => _configProvider.GetConfig<GameBoardConfig>();
        
        public MenuGameSetupModel(
            ILoadingProvider loadingProvider, 
            ITokensProvider tokensProvider, 
            IAudioService audioService,
            IConfigProvider configProvider)
        {
            _loadingProvider = loadingProvider;
            _tokensProvider = tokensProvider;
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
            Match match = new Match(matchData);
            
            _loadingProvider.LoadGame(match).Forget();
        }
        
        private IPlayer[] GetPlayers(MatchType matchType)
        {
            IPlayer player1;
            IPlayer player2;
            
            switch (matchType)
            {
                case MatchType.PlayerVsPlayer:
                    player1 = new PersonPlayer(_tokensProvider.GetRandomMarkSet().XToken,"Player 1");
                    player2 = new PersonPlayer(_tokensProvider.GetRandomMarkSet().OToken,"Player 2");
                    return new []{player1, player2};
                case MatchType.PlayerVsComp:
                    player1 = new PersonPlayer(_tokensProvider.GetRandomMarkSet().XToken,"Player 1");
                    player2 = new BotPlayer(_tokensProvider.GetRandomMarkSet().OToken, BotLevel.Hard);
                    return new []{player1, player2};
                case MatchType.CompVsComp:
                    player1 = new BotPlayer(_tokensProvider.GetRandomMarkSet().XToken, BotLevel.Easy);
                    player2 = new BotPlayer(_tokensProvider.GetRandomMarkSet().OToken, BotLevel.Hard);
                    return new []{player1, player2};
            }

            return null;
        }
    }
}