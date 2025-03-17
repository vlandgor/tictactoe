namespace Runtime.Logger
{
    public static class DSenders
    {
        public static readonly DSender Application = new(name: "[Application]".Green());
        public static readonly DSender Loading = new(name: "[Loading]".White());
        public static readonly DSender Network = new(name: "[Network]".Magenta());
    }

    public class DSender
    {
        public readonly string Name;

        public DSender(string name) => Name = name;
    }
}