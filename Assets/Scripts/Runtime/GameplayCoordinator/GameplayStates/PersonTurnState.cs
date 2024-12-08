using Cysharp.Threading.Tasks;
using Runtime.GameBoard;
using Runtime.InputService;
using UnityEngine;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class PersonTurnState : PlayerTurnState
    {
        private IInputService _inputService;
        
        
        public PersonTurnState(
            IGameplayCoordinator gameplayCoordinator,
            IGameBoard gameBoard,
            IInputService inputService) 
            : base(gameplayCoordinator, gameBoard)
        {
            _inputService = inputService;
        }
        
        public override async UniTask Enter()
        {
            Debug.Log("Enter PersonTurnState");
            
            _inputService.OnTileClicked += HandleTileClicked;
            _inputService.SetInputEnabled(true);
        }

        public override async UniTask Exit()
        {
            _inputService.OnTileClicked -= HandleTileClicked;
            _inputService.SetInputEnabled(false);
        }
        
        private async void HandleTileClicked(Crd crd)
        {
            await UpdateBoard(crd);
            CheckBoard();
            _gameplayCoordinator.ChangeTurn();
        }
    }
}