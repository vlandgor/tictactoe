using UnityEngine;
using Zenject;

namespace Runtime.GameSession
{
    public class GameSessionInstaller : MonoInstaller
    {
        [SerializeField] 
        
        public override void InstallBindings()
        {
            BindGameSession();
        }

        private void BindGameSession()
        {
            Container
                .Bind<IGameSession>()
                .To<GameSession>()
                .AsSingle();
        }
    }
}