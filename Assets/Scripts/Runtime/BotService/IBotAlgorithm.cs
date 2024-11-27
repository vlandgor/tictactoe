using Runtime.GameBoard;

namespace Runtime.BotService
{
    public interface IBotAlgorithm
    {
        public Crd GetMove();
    }
}