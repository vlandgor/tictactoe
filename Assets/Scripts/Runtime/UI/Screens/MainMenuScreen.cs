using Runtime.LoadingProvider;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Screens
{
    public class MainMenuScreen : ScreenUI
    {
        private Button _startButton;
        private Button _settingsButton;
        private Button _collectionButton;
        private Button _exitButton;
        
        private ILoadingProvider _loadingProvider;

        // [Inject]
        // public void Construct(ILoadingProvider loadingProvider)
        // {
        //     //_loadingProvider = loadingProvider;
        // }
        
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
            //_loadingProvider.LoadGame();
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