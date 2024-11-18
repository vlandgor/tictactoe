using System;
using UnityEngine.UIElements;

namespace Runtime.UI.Game.Views
{
    public class GameResultView : View
    {
        public event Action OnHomeButtonClicked;
        public event Action OnRestartButtonClicked;
        public event Action OnContinueButtonClicked;
        
        
        private VisualElement _winnerPanel;
        private Label _winnerLabel;
        
        private VisualElement _drawPanel;
        
        private Button _homeButton;
        private Button _restartButton;
        private Button _continueButton;
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _winnerPanel = _visual.Q<VisualElement>("WinnerPanel");
            _winnerLabel = _visual.Q<Label>("WinnerLabel");
            
            _drawPanel = _visual.Q<VisualElement>("DrawPanel");
            
            _homeButton = _visual.Q<Button>("HomeButton");
            _homeButton.clicked += () => OnHomeButtonClicked?.Invoke();
            
            _restartButton = _visual.Q<Button>("RestartButton");
            _restartButton.clicked += () => OnRestartButtonClicked?.Invoke();
            
            _continueButton = _visual.Q<Button>("ContinueButton");
            _continueButton.clicked += () => OnContinueButtonClicked?.Invoke();
        }
        
        public void ShowWinner(string winnerName)
        {
            _winnerPanel.style.display = DisplayStyle.Flex;
            _drawPanel.style.display = DisplayStyle.None;
            
            _winnerLabel.text = $"{winnerName} Won!";
        }
        
        public void ShowDraw()
        {
            _winnerPanel.style.display = DisplayStyle.None;
            _drawPanel.style.display = DisplayStyle.Flex;
        }
    }
}