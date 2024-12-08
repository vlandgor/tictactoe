using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class StartRoundState : GameplayState
    {
        public StartRoundState(IGameplayCoordinator gameplayCoordinator) : base(gameplayCoordinator)
        {
            
        }
        
        public override async UniTask Enter()
        {
            Debug.Log("Entered StartRoundState");
            _gameplayCoordinator.ChangeTurn();
        }

        public override async UniTask Exit()
        {
        }
    }
}