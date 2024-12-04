using Cysharp.Threading.Tasks;

namespace Runtime.MatchService.States
{
    public class FinishRoundState : IMatchState
    {
        private ILocalMatchService _localMatchService;
        private RoundResult _roundResult;
        
        public FinishRoundState(ILocalMatchService localMatchService, RoundResult roundResult)
        {
            _localMatchService = localMatchService;
            _roundResult = roundResult;
        }
        
        public async UniTask Enter()
        {
            if (_roundResult.Winner != null)
            {
                _localMatchService.MatchResult.AddScore(_roundResult.Winner);
            }
            else
            {
                _localMatchService.MatchResult.AddDraw();
            }
            
            _localMatchService.GameMediator.ShowRoundResult(_roundResult);
        }

        public void Exit()
        {
            
        }
    }
}