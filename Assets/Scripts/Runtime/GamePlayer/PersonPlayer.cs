using Runtime.Tokens;

namespace Runtime.GamePlayer
{
    public class PersonPlayer : IPlayer
    {
        public string Name { get; }
        public int SetIndex { get; }
        
        public PersonPlayer(int setIndex, string name)
        {
            SetIndex = setIndex;
            Name = name;
        }
    }
}