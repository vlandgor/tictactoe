using Runtime.UI.MainMenu.Models;
using Runtime.UI.MainMenu.Views;

namespace Runtime.UI.MainMenu.Presenters
{
    public class MainMenuPresenter
    {
        private MainMenuModel _model;
        private MainMenuView _view;

        public MainMenuPresenter(MainMenuModel model, MainMenuView view)
        {
            _model = model;
            _view = view;
        }

        public void OnStartGame()
        {
            _model.StartGame();
        }

        public void OnExitGame()
        {
            _model.ExitGame();
        }
    }
}