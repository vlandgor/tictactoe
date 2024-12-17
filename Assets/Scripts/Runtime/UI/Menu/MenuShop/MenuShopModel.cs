using Runtime.ShopService;

namespace Runtime.UI.MenuShop
{
    public class MenuShopModel : BaseModel
    {
        private IShopService _shopService;
        
        public MenuShopModel(IShopService shopService)
        {
            _shopService = shopService;
        }
        
        public ShopItem[] GetShopItems()
        {
            return _shopService.GetShopItems();
        }
    }
}