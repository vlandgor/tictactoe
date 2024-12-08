using System;
using UnityEngine;

namespace Runtime.Tokens
{
    [Serializable]
    public class TokenSet
    {
        [SerializeField] private Token xToken;
        public Token XToken => xToken;
        
        [SerializeField] private Token oToken;
        public Token OToken => oToken;
    }
}