using System.Collections.Generic;
using UnityEngine;

namespace Runtime.BoardTokens
{
    [CreateAssetMenu(fileName = "TokenStorage", menuName = "Playcbo/Storages/Token Storage", order = 0)]
    public class TokenStorage : ScriptableObject
    {
        public List<Token> tokens = new();
    }
}