using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;
using Zenject;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuHudPresenter
    {
        private MenuHudModel _hudModel;
        private MenuHudView _hudView;
        
        private readonly LazyInject<IMenuMediator> _mediator;

        public MenuHudPresenter(MenuHudModel hudModel, MenuHudView hudView, LazyInject<IMenuMediator> mediator)
        {
            _hudModel = hudModel;
            _hudView = hudView;
            
            _mediator = mediator;
        }
        
        public void OnPlay()
        {
            _hudModel.StartGame();
        }

        public void OnSettings()
        {
            _mediator.Value.ShowSettings();
        }
    }
}