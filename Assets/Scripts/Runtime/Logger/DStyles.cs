using UnityEngine.Device;

namespace Runtime.Logger
{
    public static class DStyles
    {
        public const string GreenColor = "#00FF00";
        public const string RedColor = "#FF0000";
        public const string YellowColor = "#FFFF00";
        public const string BlueColor = "#0000FF";
        public const string CyanColor = "#00FFFF";
        public const string MagentaColor = "#FF00FF";
        public const string WhiteColor = "#FFFFFF";
        public const string BlackColor = "#000000";
        public const string GrayColor = "#808080";
        
        public const string ColorClose = "</color>";
        public const string BoldOpen = "<b>";
        public const string BoldClose = "</b>";
        
        public static string Bold(this string value)
        {
            if (!Application.isEditor)
                return value.ToString();
            
            return $"{BoldOpen}{value}{BoldClose}";
        }
        
        public static string Green(this string value) => Colored(value, GreenColor);

        public static string Red(this string value) => Colored(value, RedColor);

        public static string Yellow(this string value) => Colored(value, YellowColor);

        public static string Blue(this string value) => Colored(value, BlueColor);
        
        public static string Cyan(this string value) => Colored(value, CyanColor);
        
        public static string Magenta(this string value) => Colored(value, MagentaColor);
        
        public static string White(this string value) => Colored(value, WhiteColor);
        
        public static string Black(this string value) => Colored(value, BlackColor);
        
        public static string Gray(this string value) => Colored(value, GrayColor);
        
        private static string Colored(this string value, string color)
        {
            if (!Application.isEditor)
                return value.ToString();
            
            return $"<color={color}>{value}{ColorClose}";
        }
    }
}