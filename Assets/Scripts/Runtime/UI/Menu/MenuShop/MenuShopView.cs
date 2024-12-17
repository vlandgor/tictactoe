using Runtime.ShopService;
using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI.MenuShop
{
    public class MenuShopView : BaseView
    {
        [SerializeField] private VisualTreeAsset shopItemTemplate;

        private ScrollView _contentPanel;
        private Button _closeButton;
        
        private ShopItemVisual[] _shopItemVisuals;
        
        private MenuShopPresenter MenuShopPresenter => BasePresenter as MenuShopPresenter;
        
        public void OnDestroy()
        {
            _closeButton.clicked -= MenuShopPresenter.DisableView;

            ClearItems();
        }

        protected override void InitializeVisuals()
        {
            base.InitializeVisuals();

            _contentPanel = _root.Q<ScrollView>("ContentPanel");

            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += MenuShopPresenter.DisableView;
        }

        public void InitializeItems(ShopItem[] items)
        {
            _shopItemVisuals = new ShopItemVisual[items.Length];
            for (var i = 0; i < items.Length; i++)
            {
                var item = items[i];
                VisualElement itemRoot = shopItemTemplate.CloneTree();
                _contentPanel.Add(itemRoot);

                ShopItemVisual itemVisual = _shopItemVisuals[i] = new ShopItemVisual(item);
                itemVisual.InitializeVisuals(itemRoot);

                itemVisual.OnPriceButtonClicked += HandlePriceButtonClicked;
            }
        }

        public void ClearItems()
        {
            if (_shopItemVisuals != null)
            {
                foreach (var itemVisual in _shopItemVisuals)
                {
                    if (itemVisual != null)
                    {
                        itemVisual.OnPriceButtonClicked -= HandlePriceButtonClicked;
                    }
                }
            }

            _contentPanel.Clear();
            _shopItemVisuals = null;
        }

        
        private void HandlePriceButtonClicked()
        {
            Debug.Log("Price button clicked");
        }
    }
}