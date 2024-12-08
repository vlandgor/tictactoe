using Runtime.Tokens;

namespace Runtime.GamePlayer
{
    public interface IPlayer
    {
        public string Name { get; }
        public Token Token { get; }
    }
}