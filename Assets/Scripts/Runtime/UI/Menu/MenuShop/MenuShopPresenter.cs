using Runtime.UI.Menu;

namespace Runtime.UI.MenuShop
{
    public class MenuShopPresenter : BasePresenter
    {
        private MenuShopModel _model;
        private MenuShopView _view;
        private IMenuMediator _menuMediator;
        
        public MenuShopPresenter(MenuShopModel model, MenuShopView view, IMenuMediator menuMediator)
        {
            _model = model;
            _view = view;
            _menuMediator = menuMediator;
        }
        
        public override void EnableView()
        {
            _view.Show();
            _view.InitializeItems(_model.GetShopItems());
        }

        public override void DisableView()
        {
            _view.Hide();   
            _view.ClearItems();
        }
    }
}