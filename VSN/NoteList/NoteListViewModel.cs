using System.Collections.ObjectModel;
using System.Windows.Input;
using VSN.Note;
using VSN.WPF;

namespace VSN.NoteList
{
    public class NoteListViewModel : BaseViewModel
    {
        public NoteListViewModel(MainViewModel viewModel)
        {
            ViewModel = viewModel;

            DeleteNoteCommand = new RelayCommand(DeleteNote);
        }

        public ICommand DeleteNoteCommand { get; set; }

        public MainViewModel ViewModel { get; }

        public int SelectedNoteIndex { get; set; }

        public void ListItemDoubleClick(object parameter)
        {
            if (parameter is BaseNoteViewModel note)
                ViewModel.CurrentNote = note;
        }

        public void DeleteNote() => ViewModel.DeleteNoteAtIndex(SelectedNoteIndex);
    }
}