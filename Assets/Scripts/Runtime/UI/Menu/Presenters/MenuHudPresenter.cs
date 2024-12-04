using Runtime.MatchService;
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