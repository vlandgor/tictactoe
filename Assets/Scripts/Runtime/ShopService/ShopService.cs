using UnityEngine;

namespace Runtime.ShopService
{
    public class ShopService : MonoBehaviour, IShopService
    {
        [SerializeField] private ShopItemsProvider _shopItemsProvider;

        public ShopItem[] GetShopItems()
        {
            return _shopItemsProvider.Items;
        }
    }
}