using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuHudView : View
    {
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
            _playButton.clicked += _presenter.EnableGameSetup;
            
            // _settingsButton = _root.Q<Button>("SettingsButton");
            // _settingsButton.clicked += () => _presenter.EnableSettings();
        }
    }
}