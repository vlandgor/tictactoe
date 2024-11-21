using System;
using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuHudView : View
    {
        public event Action PlayButtonClicked;
        
        private MenuHudPresenter _presenter;
        
        private Button _playButton;
        
        private Button _shopButton;
        private Button _collectionButton;
        private Button _statsButton;
        private Button _settingsButton;

        [Inject]
        public void Construct(MenuHudPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _playButton = _root.Q<Button>("PlayButton");
            _playButton.clicked += () => PlayButtonClicked?.Invoke();
            
            _shopButton = _root.Q<Button>("ShopButton");
            _shopButton.clicked += () => _presenter.EnableShop();
            
            _collectionButton = _root.Q<Button>("CollectionButton");
            _collectionButton.clicked += () => _presenter.EnableCollection();
            
            _statsButton = _root.Q<Button>("StatsButton");
            _statsButton.clicked += () => _presenter.EnableStats();
            
            _settingsButton = _root.Q<Button>("SettingsButton");
            _settingsButton.clicked += () => _presenter.EnableSettings();
        }
    }
}