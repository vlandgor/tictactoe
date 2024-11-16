using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuHudPresenter
    {
        private MenuHudModel _hudModel;
        private MenuHudView _hudView;

        public MenuHudPresenter(MenuHudModel hudModel, MenuHudView hudView)
        {
            _hudModel = hudModel;
            _hudView = hudView;
        }

        public void OnStartGame()
        {
            _hudModel.StartGame();
        }

        public void OnExitGame()
        {
            _hudModel.ExitGame();
        }
    }
}