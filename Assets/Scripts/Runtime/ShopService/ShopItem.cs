using System;
using UnityEngine;

namespace Runtime.ShopService
{
    [Serializable]
    public class ShopItem
    {
        [SerializeField] private string _name;
        public string Name => _name;
        
        [SerializeField] private Sprite _crossIcon;
        public Sprite CrossIcon => _crossIcon;
        
        [SerializeField] private Sprite _checkIcon;
        public Sprite CheckIcon => _checkIcon;
        
        [SerializeField] private int _price;
        public int Price => _price;
    }
}