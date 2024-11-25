using UnityEngine;

namespace Runtime.ShopService
{
    [CreateAssetMenu(fileName = "ShopItemsProvider", menuName = "Playcbo/Storages/Shop Storage", order = 0)]
    public class ShopItemsProvider : ScriptableObject
    {
        [SerializeField] private ShopItem[] _items;
        public ShopItem[] Items => _items;
    }
}