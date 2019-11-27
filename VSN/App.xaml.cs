using System.Windows;
using VSN.Settings;
using VSN.Utils;

namespace VSN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            SharedBindings.AppSettings = RegistryUtils.LoadSettings();

            MainWindow = new MainWindow(new MainViewModel());
            MainWindow.Show();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            RegistryUtils.SaveSettings(SharedBindings.AppSettings);
        }
    }
}
