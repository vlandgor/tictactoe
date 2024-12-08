using Cysharp.Threading.Tasks;
using Runtime.GameplayCoordinator;
using Runtime.LoadingProvider;

namespace Runtime.UI.Game.Models
{
    public class GameResultModel : Model
    {
        private ILoadingProvider _loadingProvider;
        private IGameplayCoordinator _gameplayCoordinator;
        
        public GameResultModel(
            ILoadingProvider loadingProvider,
            IGameplayCoordinator gameplayCoordinator)
        {
            _loadingProvider = loadingProvider;
            _gameplayCoordinator = gameplayCoordinator;
        }
        
        public void LoadMenu()
        {
            _loadingProvider.LoadMenu().Forget();
        }
        
        public void RestartMatch()
        {
            _gameplayCoordinator.RestartRound();
        }
    }
}