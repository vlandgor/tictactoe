using Cysharp.Threading.Tasks;
using Runtime.GameSession;

namespace Runtime.MatchService
{
    public interface IMatchService
    {
        public UniTask Initialize(MatchData matchData);
    }
}