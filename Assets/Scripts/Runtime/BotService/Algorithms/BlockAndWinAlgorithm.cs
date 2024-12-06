using Runtime.GameBoard;
using Runtime.MatchService;
using Runtime.GamePlayer;
using Runtime.MatchService.MatchProcessors;
using UnityEngine;
using Random = System.Random;

namespace Runtime.BotService.Algorithms
{
    public class BlockAndWinAlgorithm : IBotAlgorithm
    {
        private MatchProcessor _matchProcessor;
        
        private IPlayer _bot;
        private IPlayer _opponent;

        public BlockAndWinAlgorithm(MatchProcessor matchProcessor, IPlayer bot, IPlayer opponent)
        {
            _matchProcessor = matchProcessor.Clone<StandardMatchProcessor>();
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
            for (int x = 0; x < _matchProcessor.BoardSize.x; x++)
            {
                for (int y = 0; y < _matchProcessor.BoardSize.y; y++)
                {
                    Crd crd = new Crd(x, y);
                    
                    if (!_matchProcessor.CheckIfCellIsTaken(crd))
                    {
                        _matchProcessor.PlaceToken(crd, player);
                        
                        bool playerWins = _matchProcessor.CheckIfPlayerWon(player);
                        Debug.Log($"Player {player.Name} wins: {playerWins}");
                        
                        _matchProcessor.UndoPlaceToken(crd);

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
                int x = random.Next(0, _matchProcessor.BoardSize.x);
                int y = random.Next(0, _matchProcessor.BoardSize.y);
                crd = new Crd(x, y);
            } 
            while (_matchProcessor.CheckIfCellIsTaken(crd));

            return crd;
        }
    }
}
