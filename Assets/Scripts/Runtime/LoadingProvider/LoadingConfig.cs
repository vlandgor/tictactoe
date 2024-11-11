using UnityEngine;

namespace Runtime.LoadingProvider
{
    [CreateAssetMenu(fileName = "LoadingConfig", menuName = "Playcbo/Configs/Loading Config", order = 0)]
    public class LoadingConfig : ScriptableObject
    {
        [Range(1, 10)]
        [SerializeField] private float _barSpeed;
        public float BarSpeed => _barSpeed * 10;
        
        [Range(0.1f, 2f)]
        [SerializeField] private float _delayAfterLoad;
        public int DelayAfterLoad => (int)(_delayAfterLoad * 1000);
    }
}