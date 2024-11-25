using System;
using Runtime.ShopService;
using UnityEngine.UIElements;

namespace Runtime.UI.Menu
{
    public class ShopItemVisual : VisualElement
    {
        public event Action OnPriceButtonClicked;
        
        private ShopItem _shopItem;
        
        private Button _priceButton;
        
        public ShopItemVisual(ShopItem shopItem)
        {
            _shopItem = shopItem;
        }
        
        public void InitializeVisuals(VisualElement root)
        {
            Label nameLabel = root.Q<Label>("NameLabel");
            nameLabel.text = _shopItem.Name;
            
            VisualElement crossIconElement = root.Q<VisualElement>("CrossIconElement");
            crossIconElement.style.backgroundImage = _shopItem.CrossIcon.texture;
            
            VisualElement checkIconElement = root.Q<VisualElement>("CheckIconElement");
            checkIconElement.style.backgroundImage = _shopItem.CheckIcon.texture;
            
            Button priceButton = _priceButton = root.Q<Button>("PriceButton");
            priceButton.text = _shopItem.Price == 0 ? "Free" : _shopItem.Price.ToString();
            priceButton.clicked += HandlePriceButtonClicked;
        }
        
        public void OnDestroy()
        {
            _priceButton.clicked -= HandlePriceButtonClicked;
        }
        
        private void HandlePriceButtonClicked()
        {
            OnPriceButtonClicked?.Invoke();
        }
    }
}