using System.Windows;
using Microsoft.Win32;
using VSN.Settings;

namespace VSN.Utils
{
    public static class RegistryUtils
    {
        private const string RegKey = @"SOFTWARE\Spitfire\VSN";

        public static void SaveSettings(AppSettings settings)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegKey))
            {
                key.SetValue("FixedWidthFont", settings.FixedWidthFont, RegistryValueKind.DWord);
                key.SetValue("TextWrapping", settings.TextWrapping, RegistryValueKind.DWord);
            }
        }

        public static AppSettings LoadSettings()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegKey))
            {
                if (key == null || key.ValueCount <= 0) 
                    return new AppSettings();

                int fixedWidthFont = (int) key.GetValue("FixedWidthFont");
                int textWrapping = (int) key.GetValue("TextWrapping");

                return new AppSettings(fixedWidthFont == 1, textWrapping == 1);
            }
        }
    }
}