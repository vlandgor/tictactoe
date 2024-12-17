using Runtime.UI.Game.Presenters;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Game.Views
{
    public class GameResultBaseView : BaseView
    {
        private VisualElement _youWonPanel;
        private VisualElement _youLostPanel;
        
        private VisualElement _playerWonPanel;
        private Label _playerWonLabel;
        
        private VisualElement _drawPanel;
        
        private Button _settingsButton;
        private Button _restartButton;
        private Button _leaveButton;
        
        private GameResultBasePresenter GameResultBasePresenter => BasePresenter as GameResultBasePresenter;
        
        protected override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _youWonPanel = _visual.Q<VisualElement>("YouWonPanel");
            _youLostPanel = _visual.Q<VisualElement>("YouLostPanel");
            
            _playerWonPanel = _visual.Q<VisualElement>("PlayerWonPanel");
            _playerWonLabel = _visual.Q<Label>("PlayerWonLabel");
            
            _drawPanel = _visual.Q<VisualElement>("DrawPanel");
            
            _settingsButton = _visual.Q<Button>("SettingsButton");
            _settingsButton.clicked += GameResultBasePresenter.SettingsButtonPressed;
            
            _restartButton = _visual.Q<Button>("RestartButton");
            _restartButton.clicked += GameResultBasePresenter.RestartButtonPressed;
            
            _leaveButton = _visual.Q<Button>("LeaveButton");
            _leaveButton.clicked += GameResultBasePresenter.LeaveButtonPressed;
        }
        
        public void ShowYouWon()
        {
            HideAllPanels();
            _youWonPanel.style.display = DisplayStyle.Flex;
            Debug.Log("You won");
        }
        
        public void ShowYouLost()
        {
            HideAllPanels();
            _youLostPanel.style.display = DisplayStyle.Flex;
            Debug.Log("You lost");
        }
        
        public void ShowPlayerWon(string playerName)
        {
            HideAllPanels();
            _playerWonPanel.style.display = DisplayStyle.Flex;
            _playerWonLabel.text = playerName + " WON";
            Debug.Log(playerName + " won");
        }
        
        public void ShowDraw()
        {
            HideAllPanels();
            _drawPanel.style.display = DisplayStyle.Flex;
            Debug.Log("Draw");
        }
        
        private void HideAllPanels()
        {
            Debug.Log("Hide all panels");
            _youWonPanel.style.display = DisplayStyle.None;
            _youLostPanel.style.display = DisplayStyle.None;
            _playerWonPanel.style.display = DisplayStyle.None;
            _drawPanel.style.display = DisplayStyle.None;
            Debug.Log("Hide all panels");
        }
    }
}