using Cysharp.Threading.Tasks;

namespace Runtime.MatchManager
{
    public class LocalMatch
    {
        public IMatchData MatchData { get; }
        public IMatchResult MatchResult { get; }
        
        public LocalMatch(IMatchData matchData)
        { 
            MatchData = matchData;
            //MatchResult = new ClassicMatchResult();
        }
        
        public async UniTask Initialize()
        {
            
        }
    }
}