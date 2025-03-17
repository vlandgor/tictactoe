using JetBrains.Annotations;

namespace Runtime.Logger
{
    [UsedImplicitly]
    public class DLogger
    {
        public static MessageBuilder Message(DSender sender) => new(sender);
    }
}