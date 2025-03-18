using Cysharp.Threading.Tasks;
using Runtime.AudioService;
using Runtime.BoardManager;
using Runtime.ConfigProvider;
using Runtime.GameModes.ClassicMode.Board;
using Runtime.GamePlayer;
using Runtime.LoadingProvider;
using Runtime.MatchManager;
using UnityEngine;

namespace Runtime.UI.MenuMatchSetup
{
    public class MenuMatchSetupModel : BaseModel
    {
        private ILoadingProvider _loadingProvider;
        private IAudioService _audioService;
        private IConfigProvider _configProvider;
        
        private MatchMode _matchMode;
        
        public MenuMatchSetupModel(
            ILoadingProvider loadingProvider, 
            IAudioService audioService,
            IConfigProvider configProvider)
        {
            _loadingProvider = loadingProvider;
            _audioService = audioService;
            _configProvider = configProvider;
        }

        public void StartSetup(MatchMode matchMode)
        {
            _matchMode = matchMode;
        }
        
        public void StartLocalGame()
        {
            IPlayer[] players =
            {
                new PersonPlayer(0,"Player 1"),
                new PersonPlayer(1,"Player 2")
            };
            
            IMatchData matchData = new LocalMatchData(MatchType.Local, MatchMode.Classic, players);
            IBoardData boardData = new ClassicBoardData(new Vector2Int(3, 3));
            
            _loadingProvider.LoadMatch(matchData, boardData).Forget();
        }
        
        public void StartNetworkGame()
        {
            IPlayer[] players =
            {
                new PersonPlayer(0,"Player 1"),
                new PersonPlayer(1,"Player 2")
            };
            
            IMatchData matchData = new LocalMatchData(MatchType.Network, MatchMode.Classic, players);
            IBoardData boardData = new ClassicBoardData(new Vector2Int(3, 3));
            
            _loadingProvider.LoadMatch(matchData, boardData).Forget();
        }
    }
}