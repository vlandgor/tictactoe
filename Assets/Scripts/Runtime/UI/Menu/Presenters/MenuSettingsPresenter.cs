using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuSettingsPresenter : Presenter
    {
        private MenuSettingsModel _settingsModel;
        private MenuSettingsView _settingsView;

        public MenuSettingsPresenter(MenuSettingsModel settingsModel, MenuSettingsView settingsView)
        {
            _settingsModel = settingsModel;
            _settingsView = settingsView;
        }
        
        public override void EnableView() => _settingsView.Show();
        public override void DisableView() => _settingsView.Hide();
        
        public void OnMusicValueChanged(ChangeEvent<float> changedValue)
        {
            _settingsModel.MusicVolume = changedValue.newValue;
            
            _settingsView.SwitchMusicIcon(changedValue.newValue > 0);
        }
        
        public void OnSoundValueChanged(ChangeEvent<float> changedValue)
        {
            _settingsModel.SoundVolume = changedValue.newValue;
            
            _settingsView.SwitchSoundIcon(changedValue.newValue > 0);
        }
    }
}