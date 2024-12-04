using Runtime.MatchService;
using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuHudView : View
    {
        private MenuHudPresenter _presenter;

        private VisualElement _standardModePanel;
        private VisualElement _fallingTokensModePanel;
        private VisualElement _buildingTokensModePanel;
        private VisualElement _disappearingTokensModePanel;
        
        private Label _gameModeLabel;
        
        private VisualElement[] _gameModePanels;

        private Button _prevButton;
        private Button _playButton;
        private Button _nextButton;

        [Inject]
        public void Construct(MenuHudPresenter presenter)
        {
            _presenter = presenter;
        }
        
        public override void InitializeVisuals()
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
            
            _gameModeLabel = _root.Q<Label>("GameModeLabel");
            
            _playButton = _root.Q<Button>("PlayButton");
            _playButton.clicked += _presenter.EnableGameSetup;
            
            _prevButton = _root.Q<Button>("PrevButton");
            _prevButton.clicked += _presenter.PrevGameMode;
            
            _nextButton = _root.Q<Button>("NextButton");
            _nextButton.clicked += _presenter.NextGameMode;
        }
        
        public void UpdateGameModePanel(GameMode gameMode, int index)
        {
            HileAllGameModePanels();
            _gameModePanels[index].style.display = DisplayStyle.Flex;
            _gameModeLabel.text = gameMode.ToString();
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