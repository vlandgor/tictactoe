using Runtime.GameBoard;
using Runtime.MatchService;
using UnityEngine;

namespace Runtime.BotService.Algorithms
{
    public class RandomMoveAlgorithm : IBotAlgorithm
    {
        private Match _match;
        
        public RandomMoveAlgorithm(Match match)
        {
            _match = match.Clone();
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
                int x = Random.Range(0, _match.BoardSize.x);
                int y = Random.Range(0, _match.BoardSize.y);
                crd = new Crd(x, y);
            } 
            while (_match.CheckIfCellIsTaken(crd));

            return crd;
        }
    }
}