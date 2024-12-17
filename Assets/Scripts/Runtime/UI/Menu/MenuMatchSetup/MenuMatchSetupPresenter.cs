using Runtime.MatchService;
using Runtime.UI.Menu;

namespace Runtime.UI.MenuMatchSetup
{
    public class MenuMatchSetupPresenter : BasePresenter
    {
        private MenuMatchSetupModel _model;
        private MenuMatchSetupView _view;
        private IMenuMediator _mediator;

        public MenuMatchSetupPresenter(MenuMatchSetupModel model, MenuMatchSetupView view, IMenuMediator mediator)
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