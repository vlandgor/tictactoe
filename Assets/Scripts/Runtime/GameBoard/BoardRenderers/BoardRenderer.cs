using Cysharp.Threading.Tasks;
using Runtime.Tokens;
using UnityEngine;

namespace Runtime.GameBoard.BoardRenderers
{
    public abstract class BoardRenderer
    {
        protected TokensFactory _tokensFactory;
        protected GameBoardConfig _gameBoardConfig;
        
        protected Token[,] tokens;

        public BoardRenderer(
            TokensFactory tokensFactory,
            GameBoardConfig gameBoardConfig)
        {
            _tokensFactory = tokensFactory;
            _gameBoardConfig = gameBoardConfig;
            
            tokens = new Token[gameBoardConfig.BoardSize.x, gameBoardConfig.BoardSize.y];
        }
        
        public virtual async UniTask PlaceToken(Crd crd, Token tokenPrefab)
        {
            Token token = tokens[crd.x, crd.y] = _tokensFactory.Get(tokenPrefab);
            token.transform.localScale = new Vector3(_gameBoardConfig.BoardTileSize, _gameBoardConfig.BoardTileSize, 1);
            token.transform.SetPositionAndRotation(
                new Vector2(crd.x * _gameBoardConfig.BoardTileSize, crd.y * _gameBoardConfig.BoardTileSize) + 
                new Vector2( _gameBoardConfig.BoardTileSize / 2, _gameBoardConfig.BoardTileSize / 2), 
                Quaternion.identity);
        }
        
        public virtual async UniTask ClearTokens()
        {
            foreach (var token in tokens)
            {
                if (token != null)
                {
                    _tokensFactory.Reclaim(token);
                }
            }
        }
    }
}