﻿using UnityEngine.UIElements;

namespace Runtime.UI.MenuMatchSetup
{
    public class MenuMatchSetupView : BaseView
    {
        private Button _closeButton;

        private Button _playButton;
        private Button _playCompButton;
        private Button _playFriendButton;
        private Button _compVsCompButton;
        
        private MenuMatchSetupPresenter SetupPresenter => BasePresenter as MenuMatchSetupPresenter;
        
        protected override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += SetupPresenter.DisableView;
            
            _playButton = _root.Q<Button>("PlayButton");
            _playButton.clicked += SetupPresenter.PlayComp;
            
            _playCompButton = _root.Q<Button>("PlayCompButton");
            _playCompButton.clicked += SetupPresenter.PlayComp;
            
            _playFriendButton = _root.Q<Button>("PlayFriendButton");
            _playFriendButton.clicked += SetupPresenter.PlayFriend;
            
            _compVsCompButton = _root.Q<Button>("CompVsCompButton");
            _compVsCompButton.clicked += SetupPresenter.PlayCompVsComp;
        }
    }
}