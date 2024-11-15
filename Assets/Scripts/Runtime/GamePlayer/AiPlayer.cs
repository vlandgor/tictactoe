using Runtime.Marks;

namespace Runtime.GamePlayer
{
    public class AiPlayer : IPlayer
    {
        public string Name => "Comp. AI";   
        public Mark Mark { get; }
        
        public AiPlayer(Mark mark)
        {
            Mark = mark;
        }
    }
}