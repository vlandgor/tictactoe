using Runtime.MatchService;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;
using Zenject;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuGameSetupPresenter : Presenter
    {
        private MenuGameSetupModel _model;
        private MenuGameSetupView _view;
        private IMenuMediator _mediator;

        public MenuGameSetupPresenter(MenuGameSetupModel model, MenuGameSetupView view, IMenuMediator mediator)
        {
            _model = model;
            _view = view;
            _mediator = mediator;
        }

        public void StartSetup(MatchMode matchMode)
        {
            _model.StartSetup(matchMode);
            EnableView();
        }
        
        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();
        
        public void PlayComp()
        {
            _model.StartGame(MatchType.PlayerVsComp, false);
        }
        public void PlayFriend()
        {
            _model.StartGame(MatchType.PlayerVsPlayer, false);
        }
        public void PlayCompVsComp()
        {
            _model.StartGame(MatchType.CompVsComp,  false);
        }
    }
}