using Runtime.UI.Menu;

namespace Runtime.UI.MenuHud
{
    public class MenuHudPresenter : BasePresenter
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
        
        public void SetPlayerInfo(string playerName)
        {
            _view.SetPlayerInfo(playerName);
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
        
        public void EnableStoreMenu()
        {
            _mediator.ShowShop();
        }
        
        public void EnablePiecesesMenu()
        {
            _mediator.ShowPieces();
        }
        
        public void EnableQuestsMenu()
        {
            _mediator.ShowQuests();
        }
        
        public void EnableSettingsMenu()
        {
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