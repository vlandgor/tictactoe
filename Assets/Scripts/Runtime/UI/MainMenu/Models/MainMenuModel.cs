using Cysharp.Threading.Tasks;
using Runtime.GamePlayer;
using Runtime.GameSession;
using Runtime.LoadingProvider;
using Runtime.Marks;
using UnityEngine;

namespace Runtime.UI.MainMenu.Models
{
    public class MainMenuModel
    {
        private ILoadingProvider _loadingProvider;
        private IMarksProvider _marksProvider;
        
        public MainMenuModel(ILoadingProvider loadingProvider, IMarksProvider marksProvider)
        {
            _loadingProvider = loadingProvider;
            _marksProvider = marksProvider;
        }

        public void StartGame()
        {
            IPlayer player1 = new PersonPlayer("Player 1", _marksProvider.GetRandomMarkSet().XMark);
            IPlayer player2 = new PersonPlayer("Player 2", _marksProvider.GetRandomMarkSet().OMark);
            MatchData matchData = new MatchData(GameMode.PvP, player1, player2);
            
            _loadingProvider.LoadGame(matchData).Forget();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}