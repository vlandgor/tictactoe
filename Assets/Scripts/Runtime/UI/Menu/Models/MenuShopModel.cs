using Runtime.ShopService;

namespace Runtime.UI.Menu.Models
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