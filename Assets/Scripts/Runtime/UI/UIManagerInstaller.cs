using UnityEngine;
using Zenject;

namespace Runtime.UI
{
    public class UIManagerInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _uiManagerPrefab;
        [SerializeField] private UIScreenFactory _uiScreenFactory;
        
        public override void InstallBindings()
        {
            BindUIManager();
            BindUIScreenFactory();
        }

        private void BindUIManager()
        {
            Container
                .Bind<IUIManager>()
                .To<UIManager>()
                .FromComponentInNewPrefab(_uiManagerPrefab)
                .AsTransient();
        }
        
        private void BindUIScreenFactory()
        {
            Container
                .Bind<IUIScreenFactory>()
                .To<UIScreenFactory>()
                .FromComponentInNewPrefab(_uiManagerPrefab)
                .AsTransient();
        }
    }
}