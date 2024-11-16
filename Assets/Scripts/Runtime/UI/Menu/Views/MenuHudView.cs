using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuHudView : View
    {
        private Button _startButton;
        private Button _settingsButton;
        private Button _collectionButton;
        private Button _exitButton;

        private MenuHudPresenter _menuHudPresenter;
        
        [Inject]
        public void Construct(MenuHudPresenter menuHudPresenter)
        {
            _menuHudPresenter = menuHudPresenter;
        }
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _startButton = _root.Q<Button>("StartButton");
            _startButton.clicked += HandleStartButtonClicked;
            
            _settingsButton = _root.Q<Button>("SettingsButton");
            _settingsButton.clicked += HandleSettingsButtonClicked;
            
            _collectionButton = _root.Q<Button>("CollectionButton");
            _collectionButton.clicked += HandleCollectionButtonClicked;
            
            _exitButton = _root.Q<Button>("ExitButton");
            _exitButton.clicked += HandleExitButtonClicked;
        }

        private void OnDestroy()
        {
            _startButton.clicked -= HandleStartButtonClicked;
            _settingsButton.clicked -= HandleSettingsButtonClicked;
            _collectionButton.clicked -= HandleCollectionButtonClicked;
            _exitButton.clicked -= HandleExitButtonClicked;
        }

        private void HandleStartButtonClicked()
        {
            _menuHudPresenter.OnStartGame();
        }
        
        private void HandleSettingsButtonClicked()
        {
            
        }
        
        private void HandleCollectionButtonClicked()
        {
            
        }
        
        private void HandleExitButtonClicked()
        {
            
        }
    }
}