using Cysharp.Threading.Tasks;
using Runtime.Marks;

namespace Runtime.GameBoard
{
    public interface IGameBoard
    {
        public UniTask Initialize();
        public UniTask Clear();
        public UniTask PlaceToken(Coord coord, Mark markPrefab);
    }
}