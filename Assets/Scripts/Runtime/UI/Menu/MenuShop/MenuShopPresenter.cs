namespace Runtime.UI.MenuShop
{
    public class MenuShopPresenter : BasePresenter
    {
        private MenuShopModel _model;
        private MenuShopView _view;
        
        public MenuShopPresenter(MenuShopModel model, MenuShopView view)
        {
            _model = model;
            _view = view;
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