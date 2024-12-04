using Cysharp.Threading.Tasks;
using Runtime.BotService;
using Runtime.GameBoard;
using Runtime.GamePlayer;

namespace Runtime.MatchService.States
{
    public class BotMoveState : IMatchState
    {
        private ILocalMatchService _localMatchService;
        
        private IPlayer _player;
        
        private IBotService BotService => _localMatchService.BotService;
        
        public BotMoveState(ILocalMatchService localMatchService, IPlayer player)
        {
            _localMatchService = localMatchService;
            _player = player;
        }
        
        public async UniTask Enter()
        {
            BotPlayer bot = _player as BotPlayer;
            IPlayer opponent = _localMatchService.GetOpponent(_player);
            
            Crd move = BotService.GetMove(_localMatchService.Match, bot, opponent);
            
            await UniTask.Delay(500);
            
            UpdateBoard(move);
            CheckBoard();
            _localMatchService.ChangeTurn();
        }

        public void Exit()
        {
            
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
                MatchResult matchResult = new MatchResult(_localMatchService.MatchData.MatchType, _player);
                _localMatchService.ChangeState(new FinishMatchState(_localMatchService, matchResult));
                return;
            }
            
            if(_localMatchService.Match.IsBoardFull())
            {
                MatchResult matchResult = new MatchResult(_localMatchService.MatchData.MatchType, null); 
                _localMatchService.ChangeState(new FinishMatchState(_localMatchService, matchResult));
                return;
            }
        }
    }
}