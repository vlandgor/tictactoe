namespace Runtime.Logger
{
    public static class DSenders
    {
        public static readonly DSender Application = new(name: "[Application]".Green());
        public static readonly DSender UI = new(name: "[Network]".Yellow());
        public static readonly DSender Network = new(name: "[Network]".Blue());
    }

    public class DSender
    {
        public readonly string Name;

        public DSender(string name) => Name = name;
    }
}