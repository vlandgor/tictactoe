using System;
using Cysharp.Threading.Tasks;
using Runtime.BoardManager;
using Runtime.BoardManager.Local;
using Runtime.GamePieces;
using Runtime.GamePlayer;
using Runtime.Logger;
using Unity.Netcode;
using UnityEngine;
using Zenject;

namespace Runtime.MatchManager
{
    public class NetworkMatchManager : NetworkBehaviour, IMatchManager
    {
        private IBoardManager _boardManager;
        private RoundManager _roundManager;
        
        private NetworkMatchData _matchData;
        private Round[] rounds;

        private int roundNumber;
        
        [Inject]
        public void Construct(DiContainer container)
        {
            _boardManager = container.ResolveId<IBoardManager>(MatchType.Network);
            
            Debug.Log($"BoardManager: {_boardManager}");
        }
        
        public async UniTask Initialize(IMatchData matchData)
        {
            _matchData = (NetworkMatchData)matchData;
            _roundManager = new RoundManager(matchData);
            rounds = new Round[11];

            _boardManager.OnTileClicked += BoardManager_TileClicked;
            _boardManager.OnWinnerDetected += BoardManager_WinnerDetected;
            _boardManager.OnDrawDetected += BoardManager_DrawDetected;
            
            await StartMatch();
        }

        public override void OnNetworkSpawn()
        {
            DLogger.Message(DSenders.Network).WithText("Network was spawned").Log();

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
            
            _boardManager.OnTileClicked -= BoardManager_TileClicked;
            _boardManager.OnWinnerDetected -= BoardManager_WinnerDetected;
            _boardManager.OnDrawDetected -= BoardManager_DrawDetected;
            
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

            _boardManager.ClearBoard();
            _roundManager.NextRound();
        }
        
        private async void BoardManager_TileClicked(BoardPosition boardPosition)
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
            
            if (!ValidateInput())
                return;
            
            ConfirmMoveRpc(networkBoardPosition, PieceType.Cross);
        }

        [Rpc(SendTo.ClientsAndHost)]
        private void ConfirmMoveRpc(NetworkBoardPosition networkBoardPosition, PieceType pieceType)
        {
            DLogger
                .Message(DSenders.Network)
                .WithText($"Received move confirm. BoardPosition: {networkBoardPosition.Position.ToString()} PieceType: {pieceType.ToString()}")
                .Log();
            
            _boardManager.PlacePiece(_roundManager.Turn, networkBoardPosition.Position, pieceType, () => _roundManager.NextTurn());
        }
        
        private void BoardManager_WinnerDetected(IPlayer winner)
        {
            NextRound(winner);
        }
        
        private void BoardManager_DrawDetected()
        {
            NextRound(null);
        }
        
        private bool ValidateInput()
        {
            return true;
        }
        
        private void NetworkManager_OnClientConnected(ulong clientId)
        {
            DLogger.Message(DSenders.Network).WithText($"Client connected with Id: {clientId.ToString().Bold()}").Log();
        }
    }
}