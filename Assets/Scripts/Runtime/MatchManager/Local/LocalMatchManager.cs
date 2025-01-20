using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class LocalMatchManager : MonoBehaviour, IMatchManager
    {
        private IRoundManager _roundManager;
        private IBoardManager _boardManager;
        
        private LocalMatchData _matchData;

        [Inject]
        public void Construct(IRoundManager roundManager, IBoardManager boardManager)
        {
            _boardManager = boardManager;
        }
        
        public async UniTask Initialize(IMatchData matchData)
        {
            _matchData = matchData as LocalMatchData;
        }
    }
}