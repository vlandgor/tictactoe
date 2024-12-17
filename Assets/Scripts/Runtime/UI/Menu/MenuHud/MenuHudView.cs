using UnityEngine.UIElements;

namespace Runtime.UI.MenuHud
{
    public class MenuHudView : BaseView
    {
        private VisualElement _standardModePanel;
        private VisualElement _fallingTokensModePanel;
        private VisualElement _buildingTokensModePanel;
        private VisualElement _disappearingTokensModePanel;
        
        private VisualElement[] _gameModePanels;

        private Button _prevButton;
        private Button _playButton;
        private Button _nextButton;
        
        private MenuHudPresenter MenuHudPresenter => BasePresenter as MenuHudPresenter;
        
        protected override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _standardModePanel = _root.Q<VisualElement>("StandardModePanel");
            _fallingTokensModePanel = _root.Q<VisualElement>("FallingTokensModePanel");
            _buildingTokensModePanel = _root.Q<VisualElement>("BuildingTokensModePanel");
            _disappearingTokensModePanel = _root.Q<VisualElement>("DisappearingTokensModePanel");
            
            _gameModePanels = new[]
            {
                _standardModePanel,
                _fallingTokensModePanel,
                _buildingTokensModePanel,
                _disappearingTokensModePanel,
            };
            
            _playButton = _root.Q<Button>("PlayButton");
            _playButton.clicked += MenuHudPresenter.EnableGameSetup;
            
            _prevButton = _root.Q<Button>("PrevButton");
            _prevButton.clicked += MenuHudPresenter.PrevGameMode;
            
            _nextButton = _root.Q<Button>("NextButton");
            _nextButton.clicked += MenuHudPresenter.NextGameMode;
            
            UpdateGameModePanel(0);
        }
        
        public void UpdateGameModePanel(int index)
        {
            HileAllGameModePanels();
            _gameModePanels[index].style.display = DisplayStyle.Flex;
        }
        
        private void HileAllGameModePanels()
        {
            foreach (var panel in _gameModePanels)
            {
                panel.style.display = DisplayStyle.None;
            }
        }
    }
}