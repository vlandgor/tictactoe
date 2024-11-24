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
            const int maxRetries = 5; // Maximum retries to query for a lobby
            const int retryDelayMs = 1000; // Delay in milliseconds between retries

            for (int attempt = 0; attempt < maxRetries; attempt++)
            {
                try
                {
                    // Query available lobbies
                    Debug.Log("Querying for available lobbies...");
                    QueryResponse response = await Unity.Services.Lobbies.LobbyService.Instance.QueryLobbiesAsync(new QueryLobbiesOptions
                    {
                        Filters = new List<QueryFilter>
                        {
                            new QueryFilter(
                                field: QueryFilter.FieldOptions.S1,
                                op: QueryFilter.OpOptions.EQ,
                                value: "TicTacToe")
                        }
                    });

                    // Find a suitable lobby
                    Lobby lobbyToJoin = response.Results.FirstOrDefault();

                    if (lobbyToJoin != null)
                    {
                        Debug.Log($"Found lobby: {lobbyToJoin.Id} with {lobbyToJoin.Players.Count}/{lobbyToJoin.MaxPlayers} players");

                        // Join the lobby
                        _currentLobby = await Unity.Services.Lobbies.LobbyService.Instance.JoinLobbyByIdAsync(lobbyToJoin.Id);
                        Debug.Log($"Joined lobby: {_currentLobby.Id}");
                        return _currentLobby;
                    }

                    Debug.LogWarning("No suitable lobbies found.");
                }
                catch (LobbyServiceException ex)
                {
                    Debug.LogError($"Lobby query failed: {ex.Message}");
                }

                // If no lobbies found after query, retry
                Debug.Log($"Retrying... ({attempt + 1}/{maxRetries})");
                await UniTask.Delay(retryDelayMs);
            }

            // If no lobbies are found after retries, create a new lobby
            Debug.LogWarning("No lobbies found after retries. Creating a new lobby...");
            return await CreateLobby("TicTacToe_Lobby", 2);
        }

        public Lobby GetCurrentLobby()
        {
            return _currentLobby;
        }
        
        private async UniTask<Lobby> CreateLobby(string lobbyName, int maxPlayers)
        {
            try
            {
                string playerId = Unity.Services.Authentication.AuthenticationService.Instance.PlayerId;

                Lobby lobby = await Unity.Services.Lobbies.LobbyService.Instance.CreateLobbyAsync(
                    lobbyName,
                    maxPlayers,
                    new CreateLobbyOptions
                    {
                        IsPrivate = false,
                        Data = new Dictionary<string, DataObject>
                        {
                            { "GameMode", new DataObject(DataObject.VisibilityOptions.Public, "TicTacToe") },
                            { "CreatorId", new DataObject(DataObject.VisibilityOptions.Public, playerId) }
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
