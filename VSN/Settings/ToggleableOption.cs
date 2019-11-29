using VSN.WPF;

namespace VSN.Settings
{
    public class ToggleableOption : BaseViewModel
    {
        public ToggleableOption(string displayName, bool value)
        {
            DisplayName = displayName;
            Value = value;
        }

        public string DisplayName { get; }

        public bool Value { get; set; }
    }
}