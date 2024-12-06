using Cysharp.Threading.Tasks;
using Runtime.BotService;
using Runtime.GameBoard;
using Runtime.GamePlayer;
using UnityEngine;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class BotTurnState : PlayerTurnState
    {
        private IBotService _botService;
        
        private BotPlayer Bot => _player as BotPlayer;
        private IPlayer Opponent { get; set; }
        
        public BotTurnState(
            IGameplayCoordinator gameplayCoordinator,
            IGameBoard gameBoard,
            IBotService botService) 
            : base(gameplayCoordinator, gameBoard)
        {
            _botService = botService;
        }
        
        public override async UniTask Enter()
        {
            Debug.Log("Enter BotTurnState");
            
            Crd move = _botService.GetMove(_match.MatchProcessor, Bot, Opponent);
            
            await UniTask.Delay(500);
            
            UpdateBoard(move);
            CheckBoard();
            _gameplayCoordinator.ChangeTurn();
        }

        public override async UniTask Exit()
        {
            
        }
        
        public void SetOpponent(IPlayer opponent)
        {
            Opponent = opponent;
        }
    }
}