using Cysharp.Threading.Tasks;

namespace Runtime.MatchManager
{
    public interface IMatchManager
    {
        public UniTask Initialize(IMatchData matchData);
    }
}