using Zenject;

namespace Runtime.MatchService
{
    public class MatchServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMatchService();
        }

        private void BindMatchService()
        {
            Container
                .Bind<IMatchService>()
                .To<MatchService>()
                .AsSingle();
        }
    }
}