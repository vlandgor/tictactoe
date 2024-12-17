using Runtime.MatchService;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;
using Zenject;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuGameSetupBasePresenter : BasePresenter
    {
        private MenuGameSetupBaseModel _baseModel;
        private MenuGameSetupBaseView _baseView;
        private IMenuMediator _mediator;

        public MenuGameSetupBasePresenter(MenuGameSetupBaseModel baseModel, MenuGameSetupBaseView baseView, IMenuMediator mediator)
        {
            _baseModel = baseModel;
            _baseView = baseView;
            _mediator = mediator;
        }

        public void StartSetup(MatchMode matchMode)
        {
            _baseModel.StartSetup(matchMode);
            EnableView();
        }
        
        public override void EnableView() => _baseView.Show();
        public override void DisableView() => _baseView.Hide();
        
        public void PlayComp()
        {
            _baseModel.StartGame(MatchType.PlayerVsComp, false);
        }
        public void PlayFriend()
        {
            _baseModel.StartGame(MatchType.PlayerVsPlayer, false);
        }
        public void PlayCompVsComp()
        {
            _baseModel.StartGame(MatchType.CompVsComp,  false);
        }
    }
}