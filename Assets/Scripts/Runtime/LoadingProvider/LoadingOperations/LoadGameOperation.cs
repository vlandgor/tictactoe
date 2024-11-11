using System;
using Cysharp.Threading.Tasks;

namespace Runtime.LoadingProvider.LoadingOperations
{
    public class LoadGameOperation : ILoadingOperation
    {
        public string Description => "Loading Game";
        public UniTask Load(Action<float> onProgress)
        {
            throw new NotImplementedException();
        }
    }
}