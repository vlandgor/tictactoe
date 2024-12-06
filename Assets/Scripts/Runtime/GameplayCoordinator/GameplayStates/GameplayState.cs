using Cysharp.Threading.Tasks;
using Runtime.MatchService;
using Zenject;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public abstract class GameplayState
    {
        protected IGameplayCoordinator _gameplayCoordinator;
        
        protected Match _match;
        
        [Inject]
        public GameplayState(IGameplayCoordinator gameplayCoordinator)
        {
            _gameplayCoordinator = gameplayCoordinator;
        }

        public void SetData(Match match)
        {
            _match = match;
        }
        
        public abstract UniTask Enter();
        public abstract UniTask Exit();
    }
}