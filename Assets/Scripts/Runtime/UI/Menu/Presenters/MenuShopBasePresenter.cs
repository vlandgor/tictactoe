using Runtime.UI.Menu.Models;
using Runtime.UI.Menu.Views;

namespace Runtime.UI.Menu.Presenters
{
    public class MenuShopBasePresenter : BasePresenter
    {
        private MenuShopModel _model;
        private MenuShopBaseView _baseView;
        
        public MenuShopBasePresenter(MenuShopModel model, MenuShopBaseView baseView)
        {
            _model = model;
            _baseView = baseView;
        }
        
        public override void EnableView()
        {
            _baseView.Show();
            _baseView.InitializeItems(_model.GetShopItems());
        }

        public override void DisableView()
        {
            _baseView.Hide();   
            _baseView.ClearItems();
        }
    }
}