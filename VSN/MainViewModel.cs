using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VSN.Note;
using VSN.NoteList;
using VSN.WPF;

namespace VSN
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Notes = new ObservableCollection<BaseNoteViewModel>
            {
                new PlainNoteViewModel("Test", "Lorem ipsum docet"),
                new PlainNoteViewModel("Note2", "Sphinx of quartz")
            };

            NoteListViewModel = new NoteListViewModel(this);

            OpenCommand = new RelayCommand(Open);
            SaveCommand = new RelayCommand(Save);
        }

        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }

        public ObservableCollection<BaseNoteViewModel> Notes { get; set; }

        public NoteListViewModel NoteListViewModel { get; }

        public BaseNoteViewModel CurrentNote { get; set; }

        public string WindowTitle => CurrentNote != null ? "VSN - " + CurrentNote.Name : "VSN";

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}