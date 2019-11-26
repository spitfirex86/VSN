using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace VSN.NoteList
{
    /// <summary>
    /// Interaction logic for NoteListView.xaml
    /// </summary>
    public partial class NoteListView : UserControl
    {
        public NoteListView()
        {
            InitializeComponent();
        }

        private void ListItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is NoteListViewModel viewModel && sender is ListBoxItem item)
                viewModel.ListItemDoubleClick(item.Content);
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
