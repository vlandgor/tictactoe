using Runtime.MatchService;
using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuCreateGamePresenter : Presenter
    {
        private IMenuMediator _mediator;
        private MenuCreateGameModel _model;
        private MenuCreateGameView _view;

        public MenuCreateGamePresenter(IMenuMediator mediator, MenuCreateGameModel model, MenuCreateGameView view)
        {
            _mediator = mediator;
            _model = model;
            _view = view;
        }

        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();
        
        public void OnPlayerVsPlayerClicked()
        {
            _model.StartGame(GameMode.PlayerVsPlayer);
        }
        
        public void OnPlayerVsBotClicked()
        {
            _model.StartGame(GameMode.PlayerVsBot);
        }

        public void OnBotVsBotClicked()
        {
            _model.StartGame(GameMode.BotVsBot);
        }
    }
}