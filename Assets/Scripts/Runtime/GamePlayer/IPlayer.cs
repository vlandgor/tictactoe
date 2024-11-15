using Runtime.Marks;

namespace Runtime.GamePlayer
{
    public interface IPlayer
    {
        public string Name { get; }
        public Mark Mark { get; }
    }
}