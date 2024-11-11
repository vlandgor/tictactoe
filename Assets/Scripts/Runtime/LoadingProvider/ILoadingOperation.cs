using System;
using Cysharp.Threading.Tasks;

namespace Runtime.LoadingProvider
{
    public interface ILoadingOperation
    {
        public string Description { get; }
        public UniTask Load(Action<float> onProgress);
    }
}