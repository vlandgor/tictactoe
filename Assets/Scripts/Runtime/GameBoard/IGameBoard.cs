using Cysharp.Threading.Tasks;
using Runtime.BoardTokens;

namespace Runtime.GameBoard
{
    public interface IGameBoard
    {
        public UniTask Initialize(int width, int height);
        public UniTask Clear();
        public UniTask PlaceToken(Coord coord, Token tokenPrefab);
    }
}