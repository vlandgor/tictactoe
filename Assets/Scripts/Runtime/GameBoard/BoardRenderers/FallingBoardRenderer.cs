using Cysharp.Threading.Tasks;
using Runtime.GameBoard.Boards;
using Runtime.GamePlayer;
using Runtime.Tokens;
using UnityEngine;

namespace Runtime.GameBoard.BoardRenderers
{
    public class FallingBoardRenderer : BoardRenderer
    {
        private FallingBoard FallingBoard => _board as FallingBoard;
        
        public FallingBoardRenderer(
            TokensFactory tokensFactory, 
            GameBoardConfig gameBoardConfig,
            Board board) 
            : base(tokensFactory, gameBoardConfig, board)
        {
        }
        
        protected override void SubscribeToEvents()
        {
            FallingBoard.OnTokenPlaced += HandleTokenPlaced;
            FallingBoard.OnTokenMoved += HandleTokenMoved;
        }

        protected override void UnsubscribeFromEvents()
        {
            FallingBoard.OnTokenPlaced -= HandleTokenPlaced;
            FallingBoard.OnTokenMoved -= HandleTokenMoved;
        }
        
        private async void HandleTokenPlaced(Crd crd, IPlayer player)
        {
            await PlaceToken(crd, player.Token);
        }
        
        private async void HandleTokenMoved(Crd from, Crd to)
        {
            await MoveToken(from, to);
        }
        
        public override async UniTask PlaceToken(Crd crd, Token tokenPrefab)
        {
            await base.PlaceToken(crd, tokenPrefab);
        }

        private async UniTask MoveToken(Crd from, Crd to)
        {
            Token token = _tokens[from.x, from.y];
            _tokens[from.x, from.y] = null;
            _tokens[to.x, to.y] = token;

            Vector3 startTransform = token.transform.position;
            Vector3 targetTransform = new Vector2(to.x * _gameBoardConfig.BoardTileSize, to.y * _gameBoardConfig.BoardTileSize) 
                                      + new Vector2( _gameBoardConfig.BoardTileSize / 2, _gameBoardConfig.BoardTileSize / 2);

            float elapsedTime = 0f;
            float duration = 1f / 3; 

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                token.transform.position = Vector3.Lerp(startTransform, targetTransform, t);
                await UniTask.Yield(PlayerLoopTiming.Update);
            }

            token.transform.position = targetTransform;
        }
    }
}