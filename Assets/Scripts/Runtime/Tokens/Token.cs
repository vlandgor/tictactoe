using Runtime.GameBoard;
using UnityEngine;

namespace Runtime.Tokens
{
    public class Token : MonoBehaviour
    {
        [SerializeField] private GameObject _model;
        
        public TokensFactory OriginFactory { get; set; }
    }
}