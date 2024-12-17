using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuGameSetupBaseView : BaseView
    {
        private Button _closeButton;

        private Button _playButton;
        private Button _playCompButton;
        private Button _playFriendButton;
        private Button _compVsCompButton;
        
        private MenuGameSetupBasePresenter SetupBasePresenter => BasePresenter as MenuGameSetupBasePresenter;
        
        protected override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += SetupBasePresenter.DisableView;
            
            _playButton = _root.Q<Button>("PlayButton");
            _playButton.clicked += SetupBasePresenter.PlayComp;
            
            _playCompButton = _root.Q<Button>("PlayCompButton");
            _playCompButton.clicked += SetupBasePresenter.PlayComp;
            
            _playFriendButton = _root.Q<Button>("PlayFriendButton");
            _playFriendButton.clicked += SetupBasePresenter.PlayFriend;
            
            _compVsCompButton = _root.Q<Button>("CompVsCompButton");
            _compVsCompButton.clicked += SetupBasePresenter.PlayCompVsComp;
        }
    }
}