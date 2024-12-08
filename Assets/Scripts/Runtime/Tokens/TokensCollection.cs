using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Tokens
{
    [CreateAssetMenu(fileName = "TokenStorage", menuName = "Playcbo/Storages/Token Storage", order = 0)]
    public class TokensCollection : ScriptableObject
    {
        public List<TokenSet> tokens = new();
        
        public TokenSet GetRandomMarkSet()
        {
            return tokens[Random.Range(0, tokens.Count)];
        }
    }
}