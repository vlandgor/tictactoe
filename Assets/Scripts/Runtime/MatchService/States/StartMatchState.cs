using Cysharp.Threading.Tasks;

namespace Runtime.MatchService.States
{
    public class StartMatchState : IMatchState
    {
        private ILocalMatchService _localMatchService;
        
        public StartMatchState(ILocalMatchService localMatchService)
        {
            _localMatchService = localMatchService;
        }
        
        public async UniTask Enter()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}