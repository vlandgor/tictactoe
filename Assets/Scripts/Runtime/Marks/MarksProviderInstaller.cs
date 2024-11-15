using UnityEngine;
using Zenject;

namespace Runtime.Marks
{
    public class MarksProviderInstaller : MonoInstaller
    {
        [SerializeField] private MarksProvider _marksProviderPrefab;
        
        public override void InstallBindings()
        {
            MarksProvider marksProvider = Container
                .InstantiatePrefabForComponent<MarksProvider>(_marksProviderPrefab, Vector3.zero, Quaternion.identity, null);
            
            Container
                .Bind<IMarksProvider>()
                .To<MarksProvider>()
                .FromInstance(marksProvider)
                .AsSingle();
        }
    }
}