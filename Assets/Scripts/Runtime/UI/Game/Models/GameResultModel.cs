using Cysharp.Threading.Tasks;
using Runtime.LoadingProvider;
using Runtime.MatchService;

namespace Runtime.UI.Game.Models
{
    public class GameResultModel : Model
    {
        private ILoadingProvider _loadingProvider;
        private IMatchService _matchService;
        
        public GameResultModel(ILoadingProvider loadingProvider, IMatchService matchService)
        {
            _loadingProvider = loadingProvider;
            _matchService = matchService;
        }
        
        public void LoadMenu()
        {
            _loadingProvider.LoadMenu().Forget();
        }
        
        public void RestartMatch()
        {
            
        }
    }
}