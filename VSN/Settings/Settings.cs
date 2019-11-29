using System.Collections.Generic;
using VSN.WPF;

namespace VSN.Settings
{
    public class Settings : BaseViewModel
    {
        public Settings()
        {
            Dictionary = new Dictionary<string, ToggleableOption>
            {
                { "FixedWidthFont", new ToggleableOption("_Fixed-Width Font", true) },
                { "TextWrapping", new ToggleableOption("_Word Wrap", false) },
                { "AskBeforeDelete", new ToggleableOption("_Ask Before Delete", true) }
            };
        }

        public Dictionary<string, ToggleableOption> Dictionary { get; set; }
    }
}