using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuHudView : View
    {
        private MenuHudPresenter _menuHudPresenter;
        
        private Button _playButton;
        
        private Button _shopButton;
        private Button _collectionButton;
        private Button _statsButton;
        private Button _settingsButton;
        
        [Inject]
        public void Construct(MenuHudPresenter menuHudPresenter)
        {
            _menuHudPresenter = menuHudPresenter;
        }
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _playButton = _root.Q<Button>("PlayButton");
            _playButton.clicked += _menuHudPresenter.OnPlay;
            
            _shopButton = _root.Q<Button>("ShopButton");
            //_shopButton.clicked += _menuHudPresenter.OnShop;
            
            _collectionButton = _root.Q<Button>("CollectionButton");
            //_collectionButton.clicked += _menuHudPresenter.OnCollection;
            
            _statsButton = _root.Q<Button>("StatsButton");
            //_statsButton.clicked += _menuHudPresenter.OnStats;
            
            _settingsButton = _root.Q<Button>("SettingsButton");
            _settingsButton.clicked += _menuHudPresenter.OnSettings;
        }

        private void OnDestroy()
        {
            //_playButton.clicked -= _menuHudPresenter.OnStartGame;
            //_shopButton.clicked -= _menuHudPresenter.OnShop;
            //_collectionButton.clicked -= _menuHudPresenter.OnCollection;
            //_statsButton.clicked -= _menuHudPresenter.OnStats;
            _settingsButton.clicked -= _menuHudPresenter.OnSettings;
        }
    }
}