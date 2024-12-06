using Cysharp.Threading.Tasks;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class FinalizeMatchState : GameplayState
    {
        public FinalizeMatchState(IGameplayCoordinator gameplayCoordinator) : base(gameplayCoordinator)
        {
            
        }
        
        public override async UniTask Enter()
        {
            throw new System.NotImplementedException();
        }

        public override async UniTask Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}