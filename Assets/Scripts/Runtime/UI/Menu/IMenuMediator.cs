﻿using Runtime.MatchService;

namespace Runtime.UI.Menu
{
    public interface IMenuMediator
    {
        public void ShowShop();
        public void ShowSettings();
        public void ShowGameSetup(MatchMode matchMode);
    }
}