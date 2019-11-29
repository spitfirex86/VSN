using System.Collections.Generic;
using Microsoft.Win32;
using VSN.Settings;

namespace VSN.Utils
{
    public static class RegistryUtils
    {
        private const string RegKey = @"SOFTWARE\Spitfire\VSN";

        public static void SaveSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegKey))
            {
                foreach (KeyValuePair<string, ToggleableOption> option in StaticObjects.Settings.Dictionary)
                    key.SetValue(option.Key, option.Value.Value, RegistryValueKind.DWord);
            }
        }

        public static void LoadSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKey))
            {
                if (key == null || key.ValueCount <= 0) return;

                foreach (KeyValuePair<string, ToggleableOption> option in StaticObjects.Settings.Dictionary)
                {
                    int? value = (int?) key.GetValue(option.Key);
                    if (value != null) option.Value.Value = value == 1;
                }
            }
        }
    }
}