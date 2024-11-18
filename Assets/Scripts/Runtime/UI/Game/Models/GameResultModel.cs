using Cysharp.Threading.Tasks;
using Runtime.LoadingProvider;

namespace Runtime.UI.Game.Models
{
    public class GameResultModel : Model
    {
        private ILoadingProvider _loadingProvider;
        
        public GameResultModel(ILoadingProvider loadingProvider)
        {
            _loadingProvider = loadingProvider;
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