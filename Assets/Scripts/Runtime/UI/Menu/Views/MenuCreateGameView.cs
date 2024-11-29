using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuCreateGameView : View
    {
        private MenuCreateGamePresenter _presenter;

        private Button _closeButton;
        
        private Button playerVsPlayer;
        private Button playerVsBot;
        private Button botVsBot;
        
        [Inject]
        public void Construct(MenuCreateGamePresenter presenter)
        {
            _presenter = presenter;
        }
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += _presenter.DisableView;
            
            playerVsPlayer = _root.Q<Button>("PlayerVsPlayer");
            playerVsPlayer.clicked += _presenter.OnPlayerVsPlayerClicked;
            
            playerVsBot = _root.Q<Button>("PlayerVsBot");
            playerVsBot.clicked += _presenter.OnPlayerVsBotClicked;
            
            botVsBot = _root.Q<Button>("BotVsBot");
            botVsBot.clicked += _presenter.OnBotVsBotClicked;
        }
    }
}