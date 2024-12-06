using Cysharp.Threading.Tasks;
using Runtime.GameBoard;
using UnityEngine;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class InitializeMatchState : GameplayState
    {
        private IGameBoard _gameBoard;
        
        public InitializeMatchState(
            IGameplayCoordinator gameplayCoordinator,
            IGameBoard gameBoard) 
            : base(gameplayCoordinator)
        {
            _gameBoard = gameBoard;
        }
        
        public override async UniTask Enter()
        {
            Debug.Log("Entered InitializeMatchState");
            
            InitializeMatch();
            InitializeBoard();
            
            _gameplayCoordinator.ChangeState<StartRoundState>();
        }

        public override async UniTask Exit()
        {
            
        }
        
        private void InitializeMatch()
        {
            
        }
        
        private void InitializeBoard()
        {
            _gameBoard.Initialize();
        }
    }
}