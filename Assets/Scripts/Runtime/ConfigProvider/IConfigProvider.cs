using UnityEngine;

namespace Runtime.ConfigProvider
{
    public interface IConfigProvider
    {
        public T GetConfig<T>() where T : ScriptableObject;
    }
}