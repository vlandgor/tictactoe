using Cysharp.Threading.Tasks;
using Runtime.GameBoard.BoardRenderers;
using Runtime.MatchService;
using Runtime.Tokens;

namespace Runtime.GameBoard
{
    public interface IGameBoard
    {
        public UniTask Initialize(MatchMode matchMode);
        public UniTask ClearTokens();
        public UniTask PlaceToken(Crd crd, Token tokenPrefab);
    }
}