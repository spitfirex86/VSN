using System.Windows;
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
            InsertNoteCommand = new RelayCommand(InsertNote);
        }

        public ICommand DeleteNoteCommand { get; set; }
        public ICommand InsertNoteCommand { get; set; }

        public MainViewModel ViewModel { get; }

        public int SelectedNoteIndex { get; set; } = -1;

        public bool IsItemSelected => SelectedNoteIndex > -1;

        public void ListItemDoubleClick(object parameter)
        {
            if (parameter is BaseNoteViewModel note)
                ViewModel.CurrentNote = note;
        }

        public void DeleteNote() => ViewModel.DeleteNoteAtIndex(SelectedNoteIndex);

        public void InsertNote(object parameter)
        {
            if (parameter is NoteType noteType)
            {
                BaseNoteViewModel newNote = noteType.NewInstance();

                if (IsItemSelected)
                    ViewModel.Notes.Insert(SelectedNoteIndex + 1, newNote);
                else
                    ViewModel.Notes.Add(newNote);

                ViewModel.CurrentNote = newNote;
            }
        }
    }
}