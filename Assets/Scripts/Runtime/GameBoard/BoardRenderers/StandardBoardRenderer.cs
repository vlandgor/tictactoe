using Cysharp.Threading.Tasks;
using Runtime.GameBoard.Boards;
using Runtime.GamePlayer;
using Runtime.Tokens;

namespace Runtime.GameBoard.BoardRenderers
{
    public class StandardBoardRenderer : BoardRenderer
    {
        private StandardBoard StandardBoard => _board as StandardBoard;
        
        public StandardBoardRenderer(
            TokensFactory tokensFactory, 
            GameBoardConfig gameBoardConfig,
            Board board) 
            : base(tokensFactory, gameBoardConfig, board)
        {
        }
        
        protected override void SubscribeToEvents()
        {
            StandardBoard.OnTokenPlaced += HandleTokenPlaced;
        }
        
        protected override void UnsubscribeFromEvents()
        {
            StandardBoard.OnTokenPlaced -= HandleTokenPlaced;
        }

        private async void HandleTokenPlaced(Crd crd, IPlayer player)
        { 
            //await PlaceToken(crd, player.Token);
        }

        public override async UniTask PlaceToken(Crd crd, Token tokenPrefab)
        {
            await base.PlaceToken(crd, tokenPrefab);
        }
    }
}