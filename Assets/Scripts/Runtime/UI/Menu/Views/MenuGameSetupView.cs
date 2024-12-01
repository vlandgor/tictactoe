using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuGameSetupView : View
    {
        private MenuGameSetupPresenter _setupPresenter;

        private Button _closeButton;

        private Button _playButton;
        private Button _playCompButton;
        private Button _playFriendButton;
        private Button _compVsCompButton;
        
        
        [Inject]
        public void Construct(MenuGameSetupPresenter setupPresenter)
        {
            _setupPresenter = setupPresenter;
        }
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += _setupPresenter.DisableView;
            
            _playButton = _root.Q<Button>("PlayButton");
            _playButton.clicked += _setupPresenter.PlayComp;
            
            _playCompButton = _root.Q<Button>("PlayCompButton");
            _playCompButton.clicked += _setupPresenter.PlayComp;
            
            _playFriendButton = _root.Q<Button>("PlayFriendButton");
            _playFriendButton.clicked += _setupPresenter.PlayFriend;
            
            _compVsCompButton = _root.Q<Button>("CompVsCompButton");
            _compVsCompButton.clicked += _setupPresenter.PlayCompVsComp;
        }
    }
}