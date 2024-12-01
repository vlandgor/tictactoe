using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuHudPresenter : Presenter
    {
        private IMenuMediator _mediator;
        private MenuHudModel _model;
        private MenuHudView _view;

        public MenuHudPresenter(IMenuMediator mediator, MenuHudModel model, MenuHudView view)
        {
            _mediator = mediator;
            _model = model;
            _view = view;
        }

        public void EnableGameSetup()
        {
            _mediator.ShowGameSetup();
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

        public override void EnableView()
        {
            
        }
        public override void DisableView()
        {
            
        }
    }
}