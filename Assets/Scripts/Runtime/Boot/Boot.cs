using Runtime.GameBoard;
using UnityEngine;
using Zenject;

namespace Runtime.Boot
{
    public class Boot : MonoBehaviour
    {
        private IGameBoard gameBoard;
        
        [Inject]
        public void Construct(IGameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
        }
        
        private async void Start()
        {
            gameBoard.Initialize(3, 3);
        }
    }
}