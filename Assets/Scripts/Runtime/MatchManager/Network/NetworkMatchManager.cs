using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.BoardManager.Local;
using Runtime.GamePieces;
using Runtime.GamePlayer;
using Runtime.Logger;
using Unity.Netcode;
using Zenject;

namespace Runtime.MatchManager
{
    public class NetworkMatchManager : NetworkBehaviour, IMatchManager
    {
        private NetworkBoardManager _boardManager;
        private RoundManager _roundManager;
        
        private NetworkMatchData _matchData;
        private Round[] rounds;

        private int roundNumber;
        
        [Inject]
        public void Construct(DiContainer container)
        {
            _boardManager = container.ResolveId<IBoardManager>(MatchType.Network) as NetworkBoardManager;
        }
        
        public async UniTask Initialize(IMatchData matchData)
        {
            _matchData = (NetworkMatchData)matchData;
            _roundManager = new RoundManager(matchData);
            rounds = new Round[11];

            _boardManager.OnMoveRequested += BoardManager_MoveRequested;
            
            await StartMatch();
        }

        public override void OnNetworkSpawn()
        {
            DLogger
                .Message(DSenders.Network).WithText("Network was spawned")
                .Log();

            if (IsServer)
            {
                NetworkManager.Singleton.OnClientConnectedCallback += NetworkManager_OnClientConnected;
            }
        }

        public override void OnDestroy()
        {
            if (IsServer)
            {
                NetworkManager.Singleton.OnClientConnectedCallback -= NetworkManager_OnClientConnected;
            }
            
            _boardManager.OnMoveRequested -= BoardManager_MoveRequested;
            
            base.OnDestroy();
        }

        private async UniTask StartMatch()
        {
            _roundManager.FirstRound(_matchData.Players[0]);
        }

        public async UniTask FinishMatch()
        {
            
        }
        
        private void NextRound(IPlayer winner)
        {
            _roundManager.FinishRound(winner, out Round round);
            rounds[roundNumber] = round;
            roundNumber++;

            _boardManager.ClearBoardRpc();
            _roundManager.NextRound();
        }
        
        private async void BoardManager_MoveRequested(BoardPosition boardPosition)
        {
            RequestMoveRpc((int)NetworkManager.Singleton.LocalClientId, new NetworkBoardPosition(boardPosition));
        }

        [Rpc(SendTo.Server)]
        private void RequestMoveRpc(int playerId, NetworkBoardPosition networkBoardPosition)
        {
            DLogger
                .Message(DSenders.Network)
                .WithText($"Received move request. PlayerId: {playerId} at BoardPosition : {networkBoardPosition.Position.ToString()}")
                .Log();
            
            if (!ValidateMoveRequest(playerId))
                return;
            
            ConfirmMoveRpc(playerId, networkBoardPosition, _roundManager.TurnType);
        }

        [Rpc(SendTo.ClientsAndHost)]
        private void ConfirmMoveRpc(int playerId, NetworkBoardPosition networkBoardPosition, PieceType pieceType)
        {
            ConfirmMoveAsync(playerId, networkBoardPosition, pieceType).Forget();
        }

        private async UniTaskVoid ConfirmMoveAsync(int playerId, NetworkBoardPosition networkBoardPosition, PieceType pieceType)
        {
            DLogger
                .Message(DSenders.Network)
                .WithText($"Received move confirm. BoardPosition: {networkBoardPosition.Position} PieceType: {pieceType}")
                .Log();
            
            await _boardManager.PlacePiece(_matchData.Players[playerId], networkBoardPosition.Position, pieceType);

            if (IsServer)
            {
                _boardManager.CheckBoard(out IPlayer winner, out bool draw);
                if (winner != null || draw)
                {
                    NextRound(winner);
                    return;
                }   
                
                _roundManager.NextTurn();
            }
        }
        
        private bool ValidateMoveRequest(int playerId)
        {
            if (_matchData.Players[playerId] == _roundManager.Turn)
            {
                return true;
            }
            
            return false;
        }
        
        private void NetworkManager_OnClientConnected(ulong clientId)
        {
            DLogger.Message(DSenders.Network).WithText($"Client connected with Id: {clientId.ToString().Bold()}").Log();
        }
    }
}