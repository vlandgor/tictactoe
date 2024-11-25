using System;
using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuShopView : View, IDisposable
    {
        private MenuShopPresenter _menuShopPresenter;
        
        private Button _closeButton;
        
        
        
        [Inject]
        public void Construct(MenuShopPresenter menuShopPresenter)
        {
            _menuShopPresenter = menuShopPresenter;
        }

        public override void InitializeVisuals()
        {
            base.InitializeVisuals();

            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += _menuShopPresenter.DisableView;
        }

        public void Dispose()
        {
            _closeButton.clicked -= _menuShopPresenter.DisableView;
        }
    }
}