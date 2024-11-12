using Cysharp.Threading.Tasks;

namespace Runtime.UI
{
    public interface IUIManager
    {
        public UniTask ShowScreen<T>() where T : ScreenUI;
    }
}