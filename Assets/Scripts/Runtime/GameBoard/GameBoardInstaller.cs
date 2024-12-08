using Runtime.GameBoard.GameBoards;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Runtime.GameBoard
{
    public class GameBoardInstaller : MonoInstaller
    {
        [FormerlySerializedAs("_gameBoardPrefab")] [SerializeField] private GeneratedGameBoard generatedGameBoardPrefab;
        
        public override void InstallBindings()
        {
            BindGameBoard();
        }

        private void BindGameBoard()
        {
            GeneratedGameBoard generatedGameBoard = Container
                .InstantiatePrefabForComponent<GeneratedGameBoard>(generatedGameBoardPrefab, Vector3.zero, Quaternion.identity, null);

            Container
                .Bind<IGameBoard>()
                .FromInstance(generatedGameBoard)
                .AsSingle();
        }
    }
}