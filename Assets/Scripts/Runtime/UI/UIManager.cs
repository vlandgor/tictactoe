using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Runtime.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        private IUIScreenFactory _screenFactory;
        
        [Inject]
        public void Construct(IUIScreenFactory screenFactory)
        {
            _screenFactory = screenFactory;
        }

        public async UniTask ShowScreen<T>() where T : ScreenUI
        {
            ScreenUI screen = await _screenFactory.GetScreen<T>();
            screen.Show();
        }
    }
}