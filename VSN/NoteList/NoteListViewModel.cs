using System.Collections.ObjectModel;
using VSN.Note;
using VSN.WPF;

namespace VSN.NoteList
{
    public class NoteListViewModel : BaseViewModel
    {
        public NoteListViewModel(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public MainViewModel ViewModel { get; }

        public ObservableCollection<BaseNoteViewModel> Notes => ViewModel.Notes;

        public void ListItemDoubleClick(object sender)
        {
            if (sender is BaseNoteViewModel note)
                ViewModel.CurrentNote = note;
        }
    }
}