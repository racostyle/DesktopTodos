using System.Runtime.InteropServices;

namespace UtilityLib.Controls
{
    // Windows 10 1809+ ships dark variants of the native control themes
    // (scrollbars, list headers, combo buttons). Older systems ignore unknown names.
    internal static class DarkTheme
    {
        public const string EXPLORER = "DarkMode_Explorer";
        public const string ITEMS_VIEW = "DarkMode_ItemsView";
        public const string COMBO_BOX = "DarkMode_CFD";

        public static readonly Color DISABLED_TEXT_COLOR = Color.FromArgb(110, 110, 110);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(nint hWnd, string pszSubAppName, string pszSubIdList);

        [DllImport("user32.dll")]
        public static extern nint SendMessage(nint hWnd, int msg, nint wParam, nint lParam);

        [DllImport("gdi32.dll")]
        public static extern int SetTextColor(nint hdc, int color);

        [DllImport("gdi32.dll")]
        public static extern int SetBkColor(nint hdc, int color);

        [DllImport("gdi32.dll")]
        public static extern nint CreateSolidBrush(int color);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(nint hObject);

        public static TextFormatFlags ToTextFormat(ContentAlignment alignment)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak;
            switch (alignment)
            {
                case ContentAlignment.TopLeft: return flags | TextFormatFlags.Top | TextFormatFlags.Left;
                case ContentAlignment.TopCenter: return flags | TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.TopRight: return flags | TextFormatFlags.Top | TextFormatFlags.Right;
                case ContentAlignment.MiddleLeft: return flags | TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                case ContentAlignment.MiddleCenter: return flags | TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                case ContentAlignment.MiddleRight: return flags | TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                case ContentAlignment.BottomLeft: return flags | TextFormatFlags.Bottom | TextFormatFlags.Left;
                case ContentAlignment.BottomCenter: return flags | TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                default: return flags | TextFormatFlags.Bottom | TextFormatFlags.Right;
            }
        }

        public static void Apply(nint handle, string theme)
        {
            try
            {
                SetWindowTheme(handle, theme, null);
            }
            catch { }
        }
    }
}
