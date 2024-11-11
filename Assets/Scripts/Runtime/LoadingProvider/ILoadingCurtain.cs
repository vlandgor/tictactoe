using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Runtime.LoadingProvider
{
    public interface ILoadingCurtain
    {
        public UniTask Load(Queue<ILoadingOperation> loadingOperations);
        
        public UniTask ShowCurtain();
        public UniTask HideCurtain();
    }
}