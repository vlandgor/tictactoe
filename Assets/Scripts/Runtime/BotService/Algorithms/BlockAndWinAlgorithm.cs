using Runtime.GameBoard;
using Runtime.GameBoard.Boards;
using Runtime.MatchService;
using Runtime.GamePlayer;
using UnityEngine;
using Random = System.Random;

namespace Runtime.BotService.Algorithms
{
    public class BlockAndWinAlgorithm : IBotAlgorithm
    {
        private Board _board;
        
        private IPlayer _bot;
        private IPlayer _opponent;

        public BlockAndWinAlgorithm(Board board, IPlayer bot, IPlayer opponent)
        {
            _board = board.Clone<StandardBoard>();
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
            for (int x = 0; x < _board.BoardSize.x; x++)
            {
                for (int y = 0; y < _board.BoardSize.y; y++)
                {
                    Crd crd = new Crd(x, y);
                    
                    if (!_board.CheckIfCellIsTaken(crd))
                    {
                        _board.PlaceToken(crd, player);
                        
                        bool playerWins = _board.CheckIfPlayerWon(player);
                        Debug.Log($"Player {player.Name} wins: {playerWins}");
                        
                        _board.UndoPlaceToken(crd);

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
                int x = random.Next(0, _board.BoardSize.x);
                int y = random.Next(0, _board.BoardSize.y);
                crd = new Crd(x, y);
            } 
            while (_board.CheckIfCellIsTaken(crd));

            return crd;
        }
    }
}
