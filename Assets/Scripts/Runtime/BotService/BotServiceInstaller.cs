using Zenject;

namespace Runtime.BotService
{
    public class BotServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBotService();
        }

        private void BindBotService()
        {
            Container
                .Bind<IBotService>()
                .To<BotService>()
                .AsSingle();
        }
    }
}