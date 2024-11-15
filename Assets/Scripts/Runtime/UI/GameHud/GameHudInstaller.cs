using Runtime.UI.GameHud.Models;
using Runtime.UI.GameHud.Presenters;
using Runtime.UI.GameHud.Views;
using UnityEngine;
using Zenject;

namespace Runtime.UI.GameHud
{
    public class GameHudInstaller : MonoInstaller
    {
        [SerializeField] private GameHudView _view;
        
        public override void InstallBindings()
        {
            BindMainMenuProvider();
        }

        private void BindMainMenuProvider()
        {
            GameHudModel model = new GameHudModel();
            GameHudPresenter presenter = new GameHudPresenter(model, _view);
            
            Container
                .Bind<GameHudPresenter>()
                .FromInstance(presenter)
                .AsSingle();
        }
    }
}