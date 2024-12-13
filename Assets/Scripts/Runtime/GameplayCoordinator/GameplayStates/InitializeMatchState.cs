using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class InitializeMatchState : GameplayState
    {
        public InitializeMatchState(
            IGameplayCoordinator gameplayCoordinator) 
            : base(gameplayCoordinator)
        {
        }
        
        public override async UniTask Enter()
        {
            Debug.Log("Entered InitializeMatchState");
            
            _gameplayCoordinator.ChangeState<StartRoundState>();
        }

        public override async UniTask Exit()
        {
            
        }
    }
}