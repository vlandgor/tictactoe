using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;
using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuSettingsBasePresenter : BasePresenter
    {
        private MenuSettingsBaseModel _settingsBaseModel;
        private MenuSettingsBaseView _settingsBaseView;

        public MenuSettingsBasePresenter(MenuSettingsBaseModel settingsBaseModel, MenuSettingsBaseView settingsBaseView)
        {
            _settingsBaseModel = settingsBaseModel;
            _settingsBaseView = settingsBaseView;
        }
        
        public override void EnableView() => _settingsBaseView.Show();
        public override void DisableView() => _settingsBaseView.Hide();
        
        public void OnMusicValueChanged(ChangeEvent<float> changedValue)
        {
            _settingsBaseModel.MusicVolume = changedValue.newValue;
            
            _settingsBaseView.SwitchMusicIcon(changedValue.newValue > 0);
        }
        
        public void OnSoundValueChanged(ChangeEvent<float> changedValue)
        {
            _settingsBaseModel.SoundVolume = changedValue.newValue;
            
            _settingsBaseView.SwitchSoundIcon(changedValue.newValue > 0);
        }
    }
}