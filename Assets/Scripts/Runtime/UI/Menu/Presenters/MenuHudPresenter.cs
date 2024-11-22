using System;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuHudPresenter : IDisposable
    {
        private IMenuMediator _mediator;
        private MenuHudModel _model;
        private MenuHudView _view;

        public MenuHudPresenter(IMenuMediator mediator, MenuHudModel model, MenuHudView view)
        {
            _mediator = mediator;
            _model = model;
            _view = view;
            
            _view.PlayButtonClicked += HandlePlayButtonClicked;
        }
        public void Dispose()
        {
            _view.PlayButtonClicked -= HandlePlayButtonClicked;
        }

        private void HandlePlayButtonClicked()
        {
            _model.StartGame();
        }
        
        public void EnableShop()
        {
            _mediator.ShowShop();
        }
        
        public void EnableCollection()
        {
            
        }
        
        public void EnableStats()
        {
            
        }
        
        public void EnableSettings()
        {
            _model.EnableSettings();
            _mediator.ShowSettings();
        }
    }
}