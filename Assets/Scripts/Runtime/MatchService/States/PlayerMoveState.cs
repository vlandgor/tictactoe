using Cysharp.Threading.Tasks;
using Runtime.GameBoard;
using Runtime.GamePlayer;

namespace Runtime.MatchService.States
{
    public class PlayerMoveState : IMatchState
    {
        private ILocalMatchService _localMatchService;
        private IPlayer _player;
        
        public PlayerMoveState(ILocalMatchService localMatchService, IPlayer player)
        {
            _localMatchService = localMatchService;
            _player = player;
        }
        
        public async UniTask Enter()
        {
            _localMatchService.InputService.OnTileClicked += HandleTileClicked;
            _localMatchService.InputService.SetInputEnabled(true);
        }

        public void Exit()
        {
            _localMatchService.InputService.OnTileClicked -= HandleTileClicked;
            _localMatchService.InputService.SetInputEnabled(false);
        }
        
        private void HandleTileClicked(Crd crd)
        {
            UpdateBoard(crd);
            CheckBoard();
            _localMatchService.ChangeTurn();
        }
        
        private void UpdateBoard(Crd crd)
        {
            if(!_localMatchService.Match.PlaceToken(crd, _player))
            {
                return;
            }
            
            _localMatchService.GameBoard.PlaceToken(crd, _player.Mark);
        }
        
        private void CheckBoard()
        {
            if(_localMatchService.Match.CheckIfPlayerWon(_player))
            {
                MatchResult matchResult = new MatchResult(_player);
                _localMatchService.ChangeState(new FinishMatchState(_localMatchService, matchResult));
                return;
            }
            
            if(_localMatchService.Match.IsBoardFull())
            {
                MatchResult matchResult = new MatchResult(null); 
                _localMatchService.ChangeState(new FinishMatchState(_localMatchService, matchResult));
                return;
            }
        }
    }
}