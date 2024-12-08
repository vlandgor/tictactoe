﻿using System;
using Runtime.UI.Menu.Presenters;
using UnityEngine.UIElements;
using Zenject;

namespace Runtime.UI.Menu.Views
{
    public class MenuSettingsView : View, IDisposable
    {
        private MenuSettingsPresenter _presenter;
        
        private Button _closeButton;
        
        private Slider _musicSlider;
        private Slider _soundSlider;

        private VisualElement _musicOnIcon;
        private VisualElement _musicOffIcon;
        
        private VisualElement _soundOnIcon;
        private VisualElement _soundOffIcon;
        
        [Inject]
        public void Construct(MenuSettingsPresenter menuSettingsPresenter)
        {
            _presenter = menuSettingsPresenter;
        }
        
        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _closeButton = _root.Q<Button>("CloseButton");
            _closeButton.clicked += _presenter.DisableView;
            
            _musicSlider = _root.Q<Slider>("MusicSlider");
            _musicSlider.RegisterValueChangedCallback(_presenter.OnMusicValueChanged);
            _musicOnIcon = _root.Q<VisualElement>("MusicOnIcon");
            _musicOffIcon = _root.Q<VisualElement>("MusicOffIcon");
            
            _soundSlider = _root.Q<Slider>("SoundSlider");
            _soundSlider.RegisterValueChangedCallback(_presenter.OnSoundValueChanged);
            _soundOnIcon = _root.Q<VisualElement>("SoundOnIcon");
            _soundOffIcon = _root.Q<VisualElement>("SoundOffIcon");
        }

        public void SwitchMusicIcon(bool isOn)
        {
            _musicOnIcon.style.display = isOn ? DisplayStyle.Flex : DisplayStyle.None;
            _musicOffIcon.style.display = isOn ? DisplayStyle.None : DisplayStyle.Flex;
        }
        
        public void SwitchSoundIcon(bool isOn)
        {
            _soundOnIcon.style.display = isOn ? DisplayStyle.Flex : DisplayStyle.None;
            _soundOffIcon.style.display = isOn ? DisplayStyle.None : DisplayStyle.Flex;
        }

        public void Dispose()
        {
            _closeButton.clicked -= _presenter.DisableView;
            
            _musicSlider.UnregisterValueChangedCallback(_presenter.OnMusicValueChanged);
            _soundSlider.UnregisterValueChangedCallback(_presenter.OnSoundValueChanged);
        }
    }
}