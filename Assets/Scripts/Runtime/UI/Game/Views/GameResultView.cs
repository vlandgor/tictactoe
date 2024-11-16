using Runtime.UI.Game.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Game.Views
{
    public class GameResultView : View
    {
        private GameResultPresenter _gameResultPresenter;
        
        private Label _resultLabel;
        private Button _menuButton;
        
        [Inject]
        public void Construct(GameResultPresenter gameResultPresenter)
        {
            _gameResultPresenter = gameResultPresenter;
        }
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _resultLabel = _root.Q<Label>("ResultLabel");
            
            _menuButton = _root.Q<Button>("MenuButton");
            _menuButton.clicked += _gameResultPresenter.LoadMenu;
        }
        
        public void SetResultText(string text)
        {
            _resultLabel.text = text;
        }
    }
}