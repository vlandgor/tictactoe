using UnityEngine.UIElements;

namespace Runtime.UI.GameHud.Views
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
            _turnLabel.text = $"{text} turn";
        }
    }
}