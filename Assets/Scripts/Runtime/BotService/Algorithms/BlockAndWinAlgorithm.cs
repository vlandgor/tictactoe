using Runtime.GameBoard;
using Runtime.MatchService;
using Runtime.GamePlayer;
using Runtime.MatchService.MatchModes;
using UnityEngine;
using Random = System.Random;

namespace Runtime.BotService.Algorithms
{
    public class BlockAndWinAlgorithm : IBotAlgorithm
    {
        private Match _match;
        
        private IPlayer _bot;
        private IPlayer _opponent;

        public BlockAndWinAlgorithm(Match match, IPlayer bot, IPlayer opponent)
        {
            _match = match.Clone<StandardMatch>();
            _bot = bot;
            _opponent = opponent;
        }

        public Crd GetMove()
        {
            Debug.Log("Checking for a winning move.");
            Crd? winningMove = FindWinningMove(_bot);
            if (winningMove.HasValue)
                return winningMove.Value;
            
            Debug.Log("Checking for a blocking move.");
            Crd? blockingMove = FindWinningMove(_opponent);
            if (blockingMove.HasValue)
                return blockingMove.Value;

            Debug.Log("Making a random move.");
            return GetRandomMove();
        }

        private Crd? FindWinningMove(IPlayer player)
        {
            for (int x = 0; x < _match.BoardSize.x; x++)
            {
                for (int y = 0; y < _match.BoardSize.y; y++)
                {
                    Crd crd = new Crd(x, y);
                    
                    if (!_match.CheckIfCellIsTaken(crd))
                    {
                        _match.PlaceToken(crd, player);
                        
                        bool playerWins = _match.CheckIfPlayerWon(player);
                        Debug.Log($"Player {player.Name} wins: {playerWins}");
                        
                        _match.UndoPlaceToken(crd);

                        if (playerWins)
                        {
                            return crd;
                        }
                    }
                }
            }
            return null;
        }

        private Crd GetRandomMove()
        {
            Random random = new Random();
            Crd crd;

            do
            {
                int x = random.Next(0, _match.BoardSize.x);
                int y = random.Next(0, _match.BoardSize.y);
                crd = new Crd(x, y);
            } 
            while (_match.CheckIfCellIsTaken(crd));

            return crd;
        }
    }
}
