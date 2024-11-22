using Zenject;

namespace Runtime.RelayService
{
    public class RelayServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindRelayService();
        }

        private void BindRelayService()
        {
            Container
                .Bind<IRelayService>()
                .To<RelayService>()
                .AsSingle();
        }
    }
}