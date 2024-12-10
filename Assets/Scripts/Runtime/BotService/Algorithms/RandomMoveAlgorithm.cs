using Runtime.GameBoard;
using Runtime.GameBoard.Boards;
using Runtime.MatchService;
using UnityEngine;

namespace Runtime.BotService.Algorithms
{
    public class RandomMoveAlgorithm : IBotAlgorithm
    {
        private Board _board;
        
        public RandomMoveAlgorithm(Board board)
        {
            _board = board.Clone<StandardBoard>();
        }
        
        public Crd GetMove()
        {
            return GetRandomMove();
        }

        private Crd GetRandomMove()
        {
            Crd crd;

            do
            {
                int x = Random.Range(0, _board.BoardSize.x);
                int y = Random.Range(0, _board.BoardSize.y);
                crd = new Crd(x, y);
            } 
            while (_board.CheckIfCellIsTaken(crd));

            return crd;
        }
    }
}