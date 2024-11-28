using Cysharp.Threading.Tasks;
using Runtime.AudioService;
using Runtime.BotService;
using Runtime.GamePlayer;
using Runtime.LoadingProvider;
using Runtime.Marks;
using Runtime.MatchService;
using UnityEngine;

namespace Runtime.UI.Menu.Models
{
    public class MenuHudModel
    {
        private ILoadingProvider _loadingProvider;
        private IMarksProvider _marksProvider;
        private IAudioService _audioService;
        
        public MenuHudModel(ILoadingProvider loadingProvider, IMarksProvider marksProvider, IAudioService audioService)
        {
            _loadingProvider = loadingProvider;
            _marksProvider = marksProvider;
            _audioService = audioService;
        }

        public void StartGame()
        {
            IPlayer player1 = new PersonPlayer(_marksProvider.GetRandomMarkSet().XMark,"Player 1");
            //IPlayer player1 = new BotPlayer(_marksProvider.GetRandomMarkSet().XMark, BotLevel.Medium);
            
            //IPlayer player2 = new PersonPlayer(_marksProvider.GetRandomMarkSet().OMark,"Player 2");
            IPlayer player2 = new BotPlayer(_marksProvider.GetRandomMarkSet().OMark, BotLevel.Hard);
            MatchData matchData = new MatchData(GameMode.PlayerVsBot, player1, player2);
            
            _loadingProvider.LoadGame(matchData).Forget();
        }

        public void EnableSettings()
        {
            _audioService.PlayButtonClickFX();
        }
        
        public void ExitGame()
        {
            Application.Quit();
        }
    }
}