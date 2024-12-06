using Cysharp.Threading.Tasks;
using Runtime.UI.Game;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class EndRoundState : GameplayState
    {
        private IGameMediator _gameMediator;
        
        public EndRoundState(
            IGameplayCoordinator gameplayCoordinator,
            IGameMediator gameMediator) 
            : base(gameplayCoordinator)
        {
            _gameMediator = gameMediator;
        }
        
        public override async UniTask Enter()
        {
            _gameMediator.ShowRoundResult(_match.MatchData.MatchType, _match.MatchResult.LastRound);
        }

        public override async UniTask Exit()
        {
            
        }
    }
}