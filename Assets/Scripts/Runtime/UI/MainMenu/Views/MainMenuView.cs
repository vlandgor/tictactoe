using Runtime.UI.MainMenu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.MainMenu.Views
{
    public class MainMenuView : View
    {
        private Button _startButton;
        private Button _settingsButton;
        private Button _collectionButton;
        private Button _exitButton;

        private MainMenuPresenter _mainMenuPresenter;
        
        [Inject]
        public void Construct(MainMenuPresenter mainMenuPresenter)
        {
            _mainMenuPresenter = mainMenuPresenter;
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
            _mainMenuPresenter.OnStartGame();
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