using Runtime.Tokens;

namespace Runtime.GamePlayer
{
    public class PersonPlayer : IPlayer
    {
        public string Name { get; }
        public Token Token { get; }
        
        public PersonPlayer(Token token, string name)
        {
            Token = token;
            Name = name;
        }
    }
}