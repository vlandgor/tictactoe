using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace Runtime.LobbyService
{
    public class LobbyService : ILobbyService
    {
        private Lobby _currentLobby;

        public async UniTask<Lobby> QueryAndJoinLobby()
        {
            try
            {
                // Query available lobbies
                Debug.Log("Querying for available lobbies...");
                QueryResponse response = await Unity.Services.Lobbies.LobbyService.Instance.QueryLobbiesAsync(new QueryLobbiesOptions
                {
                    Filters = new List<QueryFilter>
                    {
                        // Example filter: only lobbies with a game mode "TicTacToe"
                        new QueryFilter(
                            field: QueryFilter.FieldOptions.S1,
                            op: QueryFilter.OpOptions.EQ,
                            value: "TicTacToe")
                    }
                });

                // Find a suitable lobby
                Lobby lobbyToJoin = response.Results.FirstOrDefault();

                if (lobbyToJoin == null)
                {
                    Debug.LogWarning("No suitable lobbies found. Creating a new lobby...");
                    // Create a new lobby if none are found
                    return await CreateLobby("TicTacToe_Lobby", 2);
                }

                Debug.Log($"Found lobby: {lobbyToJoin.Id} with {lobbyToJoin.Players.Count}/{lobbyToJoin.MaxPlayers} players");

                // Join the lobby
                _currentLobby = await Unity.Services.Lobbies.LobbyService.Instance.JoinLobbyByIdAsync(lobbyToJoin.Id);
                Debug.Log($"Joined lobby: {_currentLobby.Id}");
                return _currentLobby;
            }
            catch (LobbyServiceException ex)
            {
                Debug.LogError($"Failed to query or join a lobby: {ex.Message}");
                return null;
            }
        }

        public Lobby GetCurrentLobby()
        {
            return _currentLobby;
        }
        
        private async UniTask<Lobby> CreateLobby(string lobbyName, int maxPlayers)
        {
            try
            {
                Lobby lobby = await Unity.Services.Lobbies.LobbyService.Instance.CreateLobbyAsync(
                    lobbyName,
                    maxPlayers,
                    new CreateLobbyOptions
                    {
                        IsPrivate = false,
                        Data = new Dictionary<string, DataObject>
                        {
                            { "GameMode", new DataObject(DataObject.VisibilityOptions.Public, "TicTacToe") }
                        }
                    });
                
                Debug.Log("Lobby created with ID: " + lobby.Id);
                _currentLobby = lobby; // Store the created lobby
                return lobby;
            }
            catch (LobbyServiceException ex)
            {
                Debug.LogError($"Failed to create a lobby: {ex.Message}");
                return null;
            }
        }
    }
}
