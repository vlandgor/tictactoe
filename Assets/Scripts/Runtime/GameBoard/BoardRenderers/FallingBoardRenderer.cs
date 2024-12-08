using Cysharp.Threading.Tasks;
using Runtime.Tokens;

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
        }
    }
}