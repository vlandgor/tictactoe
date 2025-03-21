﻿using UnityEngine;
using UnityEngine.UIElements;

namespace Runtime.UI.GameHud
{
    public class GameHudView : BaseView
    {
        private Label _turnLabel;

        protected override void InitializeVisuals()
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