using UnityEngine.UIElements;

namespace Runtime.UI.MenuSettings
{
    public class MenuSettingsPresenter : BasePresenter
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