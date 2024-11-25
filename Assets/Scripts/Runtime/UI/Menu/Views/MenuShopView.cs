using System;
using Runtime.ShopService;
using Runtime.UI.Menu.Presenters;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuShopView : View, IDisposable
    {
        [SerializeField] private VisualTreeAsset shopItemTemplate;
        
        private MenuShopPresenter _menuShopPresenter;

        private ScrollView _contentPanel;
        private Button _closeButton;
        
        [Inject]
        public void Construct(MenuShopPresenter menuShopPresenter)
        {
            _menuShopPresenter = menuShopPresenter;
        }

        public override void InitializeVisuals()
        {
            base.InitializeVisuals();

            _contentPanel = _root.Q<ScrollView>("ContentPanel");

            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += _menuShopPresenter.DisableView;
        }

        public void InitializeItems(ShopItem[] items)
        {
            foreach (ShopItem item in items)
            {
                VisualElement itemRoot = shopItemTemplate.CloneTree();
                _contentPanel.Add(itemRoot);

                ShopItemVisual itemVisual = new ShopItemVisual(item);
                itemVisual.InitializeVisuals(itemRoot);
            }
        }
        
        public void ClearItems()
        {
            _contentPanel.Clear();
        }

        public void Dispose()
        {
            _closeButton.clicked -= _menuShopPresenter.DisableView;
        }
    }
}