using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Tokens
{
    public class TokensProvider : MonoBehaviour, ITokensProvider
    {
        [FormerlySerializedAs("marksCollection")] [SerializeField] private TokensCollection tokensCollection;
        
        public TokenSet GetRandomMarkSet()
        {
            return tokensCollection.GetRandomMarkSet();
        }
    }
}