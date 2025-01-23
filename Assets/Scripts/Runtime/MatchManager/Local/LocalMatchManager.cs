using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class LocalMatchManager : MonoBehaviour, IMatchManager
    {
        private IBoardManager _boardManager;
        
        private LocalMatchData _matchData;

        [Inject]
        public void Construct(DiContainer container)
        {
            _boardManager = container.ResolveId<IBoardManager>(MatchType.Local);
            
            Debug.Log($"Construct: {_boardManager == null}");
        }
        
        public async UniTask Initialize(IMatchData matchData)
        {
            Debug.Log("Initialize Match Manager");
            _matchData = (LocalMatchData)matchData;

            Debug.Log($"BoardManager: {_boardManager != null}");
            _boardManager.OnTileClicked += HandleTileClicked;
        }

        private void OnDestroy()
        {
            _boardManager.OnTileClicked -= HandleTileClicked;
        }
        
        private async void HandleTileClicked(Vector2Int coordinate)
        {
            Debug.Log($"LocalMatchManager handle tile clicked");
            
            if (!ValidateInput(coordinate))
                return;
            
            await _boardManager.PlacePiece(_matchData.Players[0], coordinate);
        }

        private bool ValidateInput(Vector2Int coordinate)
        {
            //TODO: Add validation
            
            return true;
        }
    }
}