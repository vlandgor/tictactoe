using Runtime.UI.Boot;
using UnityEngine;

namespace Runtime.UI.BootAuthentication
{
    public class BootAuthenticationPresenter : BasePresenter
    {
        private readonly IBootMediator _bootMediator;
        private readonly BootAuthenticationModel _model;
        private readonly BootAuthenticationView _view;
        
        public BootAuthenticationPresenter(
            IBootMediator bootMediator,
            BootAuthenticationModel model, BootAuthenticationView view)
        {
            _bootMediator = bootMediator;
            _model = model;
            _view = view;
        }
        
        public override void EnableView()
        {
            Debug.Log("EnableView");
        }

        public override void DisableView()
        {
            Debug.Log("DisableView");
        }
    }
}