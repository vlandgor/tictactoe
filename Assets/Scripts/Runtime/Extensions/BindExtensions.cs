using Runtime.UI;
using Zenject;

namespace Runtime.Extensions
{
    public static class BindExtensions
    {
        public static void BindUIPresenter<TPresenter, TModel, TView>(this DiContainer container, ViewsFactory factory)
            where TPresenter : BasePresenter
            where TModel : BaseModel
            where TView : BaseView
        {
            TModel model = container.Instantiate<TModel>();
            TView view = factory.Get<TView>();

            container
                .Bind<TPresenter>()
                .AsSingle()
                .WithArguments(model, view)
                .Lazy();

            view.Initialize(container.Resolve<TPresenter>());
        }
    }
}