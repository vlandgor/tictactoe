using Cysharp.Threading.Tasks;
using Runtime.AudioService;
using Runtime.BoardManager;
using Runtime.BotService;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using Runtime.GameModes.ClassicMode.Board;
using Runtime.GamePlayer;
using Runtime.LoadingProvider;
using Runtime.MatchManager;
using Runtime.Tokens;
using UnityEngine;
using MatchMode = Runtime.MatchService.MatchMode;
using MatchType = Runtime.MatchService.MatchType;

namespace Runtime.UI.MenuMatchSetup
{
    public class MenuMatchSetupModel : BaseModel
    {
        private ILoadingProvider _loadingProvider;
        private ITokensProvider _tokensProvider;
        private IAudioService _audioService;
        private IConfigProvider _configProvider;
        
        private MatchMode _matchMode;
        
        private GameBoardConfig GameBoardConfig => _configProvider.GetConfig<GameBoardConfig>();
        
        public MenuMatchSetupModel(
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

            IMatchData matchData = new LocalMatchData(MatchManager.MatchType.Local, MatchManager.MatchMode.Classic, players);
            IBoardData boardData = new ClassicBoardData(new Vector2Int(3, 3));
            
            _loadingProvider.LoadGame(matchData, boardData).Forget();
        }
        
        private IPlayer[] GetPlayers(MatchType matchType)
        {
            IPlayer player1;
            IPlayer player2;
            
            switch (matchType)
            {
                case MatchType.PlayerVsPlayer:
                    player1 = new PersonPlayer(0,"Player 1");
                    player2 = new PersonPlayer(1,"Player 2");
                    return new []{player1, player2};
                case MatchType.PlayerVsComp:
                    player1 = new PersonPlayer(0,"Player 1");
                    player2 = new BotPlayer(1, BotLevel.Hard);
                    return new []{player1, player2};
                case MatchType.CompVsComp:
                    player1 = new BotPlayer(0, BotLevel.Easy);
                    player2 = new BotPlayer(1, BotLevel.Hard);
                    return new []{player1, player2};
            }

            return null;
        }
    }
}