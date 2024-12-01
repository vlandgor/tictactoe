using Runtime.MatchService;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuGameSetupPresenter : Presenter
    {
        private IMenuMediator _mediator;
        private MenuGameSetupModel _setupModel;
        private MenuGameSetupView _setupView;

        public MenuGameSetupPresenter(IMenuMediator mediator, MenuGameSetupModel setupModel, MenuGameSetupView setupView)
        {
            _mediator = mediator;
            _setupModel = setupModel;
            _setupView = setupView;
        }

        public override void EnableView() => _setupView.Show();
        public override void DisableView() => _setupView.Hide();
        
        public void PlayComp()
        {
            _setupModel.StartGame(GameMode.PlayerVsComp);
        }
        
        public void PlayFriend()
        {
            _setupModel.StartGame(GameMode.PlayerVsPlayer);
        }
        
        public void PlayCompVsComp()
        {
            _setupModel.StartGame(GameMode.CompVsComp);
        }
    }
}