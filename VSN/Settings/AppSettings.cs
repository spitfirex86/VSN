using VSN.WPF;

namespace VSN.Settings
{
    public class AppSettings : BaseViewModel
    {
        public AppSettings(bool fixedWidthFont = true, bool textWrapping = false)
        {
            FixedWidthFont = fixedWidthFont;
            TextWrapping = textWrapping;
        }

        public bool FixedWidthFont { get; set; }

        public bool TextWrapping { get; set; }
    }
}