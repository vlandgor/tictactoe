using System;
using Cysharp.Threading.Tasks;
using Runtime.GameBoard.Boards;
using Runtime.Tokens;
using UnityEngine;

namespace Runtime.GameBoard.BoardRenderers
{
    public abstract class BoardRenderer : IDisposable
    {
        protected TokensFactory _tokensFactory;
        protected GameBoardConfig _gameBoardConfig;
        
        protected Board _board; 
        protected Token[,] _tokens;

        public BoardRenderer(
            TokensFactory tokensFactory,
            GameBoardConfig gameBoardConfig,
            Board board)
        {
            _tokensFactory = tokensFactory;
            _gameBoardConfig = gameBoardConfig;
            
            _board = board;
            _tokens = new Token[gameBoardConfig.BoardSize.x, gameBoardConfig.BoardSize.y];
            
            SubscribeToEvents();
        }

        public virtual void Dispose()
        {
            UnsubscribeFromEvents();
        }
        
        public virtual async UniTask PlaceToken(Crd crd, Token tokenPrefab)
        {
            Token token = _tokens[crd.x, crd.y] = _tokensFactory.Get(tokenPrefab);
            token.transform.localScale = new Vector3(_gameBoardConfig.BoardTileSize, _gameBoardConfig.BoardTileSize, 1);
            token.transform.SetPositionAndRotation(
                new Vector2(crd.x * _gameBoardConfig.BoardTileSize, crd.y * _gameBoardConfig.BoardTileSize) + 
                new Vector2( _gameBoardConfig.BoardTileSize / 2, _gameBoardConfig.BoardTileSize / 2), 
                Quaternion.identity);
        }
        public virtual async UniTask ClearTokens()
        {
            foreach (var token in _tokens)
            {
                if (token != null)
                {
                    _tokensFactory.Reclaim(token);
                }
            }
        }

        protected abstract void SubscribeToEvents();
        protected abstract void UnsubscribeFromEvents();
    }
}