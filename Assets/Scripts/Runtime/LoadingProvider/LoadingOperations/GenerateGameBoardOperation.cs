using System;
using Cysharp.Threading.Tasks;
using Runtime.Extensions;
using Runtime.GameBoard;
using Runtime.GameBoard.Boards;
using Zenject;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class GenerateGameBoardOperation : ILoadingOperation
    {
        private const string GAME_SCENE_NAME = "Game_Scene";
        
        private Board _board;
        
        public string Description => "Generating Game Board";
        
        public GenerateGameBoardOperation(Board board)
        {
            _board = board;
        }
        
        public async UniTask Load(Action<float> onProgress)
        {
            onProgress?.Invoke(10f);
            
            SceneContext sceneContext = LoadingExtensions.FindSceneContext(GAME_SCENE_NAME);
            IGameBoard gameBoard = sceneContext.Container.Resolve<IGameBoard>();
            
            onProgress?.Invoke(50f);
            
            await gameBoard.Initialize(_board);
            
            onProgress?.Invoke(100f);
        }
    }
}