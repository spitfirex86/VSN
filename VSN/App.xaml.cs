using System.Windows;

namespace VSN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow(new MainViewModel());
            MainWindow.Show();
        }
    }
}
