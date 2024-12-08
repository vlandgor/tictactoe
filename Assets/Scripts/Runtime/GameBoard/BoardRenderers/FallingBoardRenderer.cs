using Cysharp.Threading.Tasks;
using Runtime.Tokens;
using UnityEngine;

namespace Runtime.GameBoard.BoardRenderers
{
    public class FallingBoardRenderer : BoardRenderer
    {
        public FallingBoardRenderer(
            TokensFactory tokensFactory, 
            GameBoardConfig gameBoardConfig) 
            : base(tokensFactory, gameBoardConfig)
        {
            
        }
        
        public override async UniTask PlaceToken(Crd crd, Token tokenPrefab)
        {
            await base.PlaceToken(crd, tokenPrefab);
            await MoveToken(crd, GetFallingCrd(crd));
        }
        
        private async UniTask MoveToken(Crd from, Crd to)
        {
            Debug.Log("MoveToken");
            Token token = tokens[from.x, from.y];
            tokens[from.x, from.y] = null;
            tokens[to.x, to.y] = token;

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

        private Crd GetFallingCrd(Crd origin)
        {
            for (int i = origin.y; i >= 0; i--)
            {
                if (i == 0 || tokens[origin.x, i - 1] != null)
                {
                    return new Crd(origin.x, i);
                }
            }
            
            return origin;
        }
    }
}