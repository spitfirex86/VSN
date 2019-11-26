using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace VSN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                ContextMenu contextMenu = button.ContextMenu;
                contextMenu.PlacementTarget = button;
                contextMenu.Placement = PlacementMode.Bottom;
                contextMenu.IsOpen = true;
            }
        }
    }
}
