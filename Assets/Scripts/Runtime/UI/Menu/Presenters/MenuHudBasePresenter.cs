using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuHudBasePresenter : BasePresenter
    {
        private MenuHudModel _model;
        private MenuHudBaseView _baseView;
        private IMenuMediator _mediator;

        public MenuHudBasePresenter(MenuHudModel model, MenuHudBaseView baseView, IMenuMediator mediator)
        {
            _model = model;
            _baseView = baseView;
            _mediator = mediator;
        }

        public void EnableGameSetup()
        {
            _mediator.ShowGameSetup(_model.CurrentMatchMode);
        }
        
        public void PrevGameMode()
        {
            _model.PrevGameMode();
            _baseView.UpdateGameModePanel((int)_model.CurrentMatchMode);
        }
        
        public void NextGameMode()
        {
            _model.NextGameMode();
            _baseView.UpdateGameModePanel((int)_model.CurrentMatchMode);
        }

        public override void EnableView()
        {
            
        }
        public override void DisableView()
        {
            
        }
    }
}