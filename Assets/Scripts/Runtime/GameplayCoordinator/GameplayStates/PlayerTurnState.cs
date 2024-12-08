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
        
        protected virtual void UpdateBoard(Crd crd)
        {
            if(!_match.MatchProcessor.PlaceToken(crd, _player))
            {
                return;
            }
            
            _gameBoard.PlaceToken(crd, _player.Token);
        }
        protected virtual void CheckBoard()
        {
            if(_match.MatchProcessor.CheckIfPlayerWon(_player))
            {
                _match.MatchResult.FinishRound(_player);
                _gameplayCoordinator.ChangeState<EndRoundState>();
                return;
            }
            
            if(_match.MatchProcessor.IsBoardFull())
            {
                _match.MatchResult.FinishRound(null);
                _gameplayCoordinator.ChangeState<EndRoundState>();
            }
        }
    }
}