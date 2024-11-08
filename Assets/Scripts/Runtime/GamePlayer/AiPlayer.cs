using Runtime.BoardTokens;

namespace Runtime.GamePlayer
{
    public class AiPlayer : IPlayer
    {
        public Token Token { get; set; }
        
        public AiPlayer(Token token)
        {
            Token = token;
        }
    }
}