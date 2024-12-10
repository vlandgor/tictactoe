using Cysharp.Threading.Tasks;
using Runtime.GameBoard;
using Runtime.GamePlayer;

namespace Runtime.GameplayCoordinator.GameplayStates
{
    public class PlayerTurnState : GameplayState
    {
        protected IPlayer _player;
        protected IGameBoard _gameBoard;
        
        public PlayerTurnState(
            IGameplayCoordinator gameplayCoordinator,
            IGameBoard gameBoard) : 
            base(gameplayCoordinator)
        {
            _gameBoard = gameBoard;
        }

        public override async UniTask Enter()
        {
            
        }
        public override async UniTask Exit()
        {
            
        }
        
        public void SetPlayer(IPlayer player)
        {
            _player = player;
        }
        
        protected virtual async UniTask UpdateBoard(Crd crd)
        {
            _match.Board.PlaceToken(crd, _player);
            //await _gameBoard.PlaceToken(crd, _player.Token);
        }
        protected virtual void CheckBoard()
        {
            if(_match.Board.CheckIfPlayerWon(_player))
            {
                _match.EndRound(_player);
                _gameplayCoordinator.ChangeState<EndRoundState>();
                return;
            }
            
            if(_match.Board.IsBoardFull())
            {
                _match.EndRound(null);
                _gameplayCoordinator.ChangeState<EndRoundState>();
            }
        }
    }
}