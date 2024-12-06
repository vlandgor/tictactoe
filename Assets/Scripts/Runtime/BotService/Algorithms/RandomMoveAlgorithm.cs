using Runtime.GameBoard;
using Runtime.MatchService;
using Runtime.MatchService.MatchProcessors;
using UnityEngine;

namespace Runtime.BotService.Algorithms
{
    public class RandomMoveAlgorithm : IBotAlgorithm
    {
        private MatchProcessor _matchProcessor;
        
        public RandomMoveAlgorithm(MatchProcessor matchProcessor)
        {
            _matchProcessor = matchProcessor.Clone<StandardMatchProcessor>();
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
                int x = Random.Range(0, _matchProcessor.BoardSize.x);
                int y = Random.Range(0, _matchProcessor.BoardSize.y);
                crd = new Crd(x, y);
            } 
            while (_matchProcessor.CheckIfCellIsTaken(crd));

            return crd;
        }
    }
}