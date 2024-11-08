using Runtime.BoardTokens;

namespace Runtime.GamePlayer
{
    public class PersonPlayer : IPlayer
    {
        public Token Token { get; }
        
        public PersonPlayer(Token token)
        {
            Token = token;
        }
    }
}