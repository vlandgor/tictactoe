using Cysharp.Threading.Tasks;

namespace Runtime.MatchService.States
{
    public class FinishMatchState : IMatchState
    {
        private ILocalMatchService _localMatchService;
        private MatchResult _matchResult;
        
        public FinishMatchState(ILocalMatchService localMatchService, MatchResult matchResult)
        {
            _localMatchService = localMatchService;
            _matchResult = matchResult;
        }
        
        public async UniTask Enter()
        {
            _localMatchService.GameMediator.ShowGameResult(_matchResult);
        }

        public void Exit()
        {
            
        }
    }
}