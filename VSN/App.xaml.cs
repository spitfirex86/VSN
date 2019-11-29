using System.Windows;
using System.Windows.Shell;
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
            RegistryUtils.LoadSettings();

            JumpList jumpList = new JumpList {ShowRecentCategory = true};
            JumpList.SetJumpList(Current, jumpList);

            MainWindow = new MainWindow(new MainViewModel(e.Args.Length == 1 ? e.Args[0] : null));
            MainWindow.Show();
        }

        private void OnExit(object sender, ExitEventArgs e)
        {
            RegistryUtils.SaveSettings();
        }
    }
}
