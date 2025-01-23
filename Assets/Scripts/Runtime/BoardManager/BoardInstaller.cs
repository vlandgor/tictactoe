using Runtime.GameModes.ClassicMode.Board;
using Runtime.MatchManager;
using UnityEngine;
using Zenject;

namespace Runtime.BoardManager
{
    public class BoardInstaller : MonoInstaller
    {
        [Header("Board Managers")]
        [SerializeField] private LocalBoardManager localBoardManager;
        [SerializeField] private NetworkBoardManager networkBoardManager;

        [Header("Board Visuals")] 
        [SerializeField] private ClassicBoardVisual classicBoardVisual;
        
        public override void InstallBindings()
        {
            BindBoard();
            BindBoardVisual();
            BindBoardManager();
        }
        
        private void BindBoardManager()
        {
            Container
                .Bind<IBoardManager>()
                .WithId(MatchType.Local)
                .To<LocalBoardManager>()
                .FromInstance(localBoardManager)
                .AsTransient();

            Container
                .Bind<IBoardManager>()
                .WithId(MatchType.Network)
                .To<NetworkBoardManager>()
                .FromInstance(networkBoardManager)
                .AsTransient();
        }
        
        private void BindBoard()
        {
            Container
                .Bind<IBoard>()
                .WithId(MatchMode.Classic)
                .To<ClassicBoard>()
                .AsTransient();
        }

        private void BindBoardVisual()
        {
            Container
                .Bind<IBoardVisual>()
                .WithId(MatchMode.Classic)
                .To<ClassicBoardVisual>()
                .FromInstance(classicBoardVisual)
                .AsTransient();
        }
    }
}