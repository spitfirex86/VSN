using System.ComponentModel;
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
                contextMenu.PlacementTarget = ExpanderButtonAdd;
                contextMenu.Placement = PlacementMode.Right;
                contextMenu.IsOpen = true;
            }
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            if (!(DataContext is MainViewModel viewModel)) return;
            if (viewModel.Notes == null || viewModel.Notes.Count == 0) return;

            var result = MessageBox.Show("Do you want to save changes before exiting?", "VSN",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    viewModel.Save();
                    return;

                case MessageBoxResult.No:
                    return;

                default:
                    e.Cancel = true;
                    return;
            }

        }
    }
}
