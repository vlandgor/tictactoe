using System;
using Runtime.ConfigProvider;
using Runtime.GameBoard;
using UnityEngine;
using Zenject;

namespace Runtime.InputService
{
    public class InputService : MonoBehaviour, IInputService
    {
        public event Action<int, int> OnTileClicked;
        
        private GameBoardConfig _gameBoardConfig;

        [Inject]
        public void Construct(IConfigProvider configProvider)
        {
            _gameBoardConfig = configProvider.GetConfig<GameBoardConfig>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                clickPosition.z = 0;

                int x = Mathf.FloorToInt(clickPosition.x);
                int y = Mathf.FloorToInt(clickPosition.y);
                
                if (x < 0 || x >= _gameBoardConfig.BoardSize.x * _gameBoardConfig.BoardTileSize || y < 0 || y >= _gameBoardConfig.BoardSize.y * _gameBoardConfig.BoardTileSize)
                {
                    return;
                }
                
                OnTileClicked?.Invoke(x, y);
            }
        }
    }
}