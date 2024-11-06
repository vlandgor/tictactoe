using UnityEngine;
using Zenject;

namespace Runtime.GameBoard
{
    public class GameBoardInstaller : MonoInstaller
    {
        [SerializeField] private GameBoard _gameBoardPrefab;
        
        public override void InstallBindings()
        {
            BindGameBoard();
        }

        private void BindGameBoard()
        {
            GameBoard gameBoard = Container
                .InstantiatePrefabForComponent<GameBoard>(_gameBoardPrefab, Vector3.zero, Quaternion.identity, null);

            Container
                .Bind<IGameBoard>()
                .FromInstance(gameBoard)
                .AsSingle();
        }
    }
}