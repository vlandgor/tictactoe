using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI.Game.Views
{
    public class GameHudView : View
    {
        private Label _turnLabel;

        public override void InitializeVisuals()
        {
            base.InitializeVisuals();
            
            _turnLabel = _root.Q<Label>("TurnLabel");
        }
        
        public void UpdateTurnLabel(string text)
        {
            Debug.Log(_turnLabel == null);
            //_turnLabel.text = $"{text} turn";
        }
    }
}