using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuShopPresenter : Presenter
    {
        private MenuShopModel _model;
        private MenuShopView _view;
        
        public MenuShopPresenter(MenuShopModel model, MenuShopView view)
        {
            _model = model;
            _view = view;
        }
        
        public override void EnableView() => _view.Show();
        public override void DisableView() => _view.Hide();
    }
}