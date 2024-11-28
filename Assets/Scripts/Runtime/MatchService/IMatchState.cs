using Cysharp.Threading.Tasks;

namespace Runtime.MatchService
{
    public interface IMatchState
    {
        public UniTask Enter();
        public void Exit();
    }
}