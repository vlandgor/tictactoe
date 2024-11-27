using Runtime.Marks;

namespace Runtime.GamePlayer
{
    public class PersonPlayer : IPlayer
    {
        public string Name { get; }
        public Mark Mark { get; }
        
        public PersonPlayer(Mark mark, string name)
        {
            Mark = mark;
            Name = name;
        }
    }
}