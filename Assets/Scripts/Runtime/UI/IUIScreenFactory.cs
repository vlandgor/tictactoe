using Cysharp.Threading.Tasks;

namespace Runtime.UI
{
    public interface IUIScreenFactory
    {
        public UniTask<T> GetScreen<T>() where T : ScreenUI;
    }
}