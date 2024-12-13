using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuHudPresenter : Presenter
    {
        private MenuHudModel _model;
        private MenuHudView _view;
        private IMenuMediator _mediator;

        public MenuHudPresenter(MenuHudModel model, MenuHudView view, IMenuMediator mediator)
        {
            _model = model;
            _view = view;
            _mediator = mediator;
        }

        public void EnableGameSetup()
        {
            _mediator.ShowGameSetup(_model.CurrentMatchMode);
        }
        
        public void PrevGameMode()
        {
            _model.PrevGameMode();
            _view.UpdateGameModePanel((int)_model.CurrentMatchMode);
        }
        
        public void NextGameMode()
        {
            _model.NextGameMode();
            _view.UpdateGameModePanel((int)_model.CurrentMatchMode);
        }

        public override void EnableView()
        {
            
        }
        public override void DisableView()
        {
            
        }
    }
}