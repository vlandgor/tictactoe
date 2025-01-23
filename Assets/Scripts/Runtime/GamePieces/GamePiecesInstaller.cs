using UnityEngine;
using Zenject;

namespace Runtime.GamePieces
{
    public class GamePiecesInstaller : MonoInstaller
    {
        [SerializeField] private PieceProvider _pieceProviderPrefab;
        
        public override void InstallBindings()
        {
            BindPieceProvider();
        }

        private void BindPieceProvider()
        {       
            PieceProvider piecesProvider = Container
                .InstantiatePrefabForComponent<PieceProvider>(_pieceProviderPrefab, Vector3.zero, Quaternion.identity, null);
            
            Container
                .Bind<IPieceProvider>()
                .To<PieceProvider>()
                .FromInstance(piecesProvider)
                .AsSingle();
        }
    }
}