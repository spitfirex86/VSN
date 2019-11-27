using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using Microsoft.Win32;
using VSN.Note;
using VSN.NoteList;
using VSN.Utils;
using VSN.WPF;

namespace VSN
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Notes = new ObservableCollection<BaseNoteViewModel>();
            Notes.CollectionChanged += NotesOnCollectionChanged;

            NoteListViewModel = new NoteListViewModel(this);

            OpenCommand = new RelayCommand(Open);
            SaveCommand = new RelayCommand(Save);
            SaveAsCommand = new RelayCommand(SaveAs);
            AddNoteCommand = new RelayCommand(AddNote);
            DeleteCurrentNoteCommand = new RelayCommand(DeleteCurrentNote);
            PreviousNoteCommand = new RelayCommand(PreviousNote);
            NextNoteCommand = new RelayCommand(NextNote);
        }

        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand AddNoteCommand { get; }
        public ICommand DeleteCurrentNoteCommand { get; }
        public ICommand PreviousNoteCommand { get; }
        public ICommand NextNoteCommand { get; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public ObservableCollection<BaseNoteViewModel> Notes { get; set; }

        public NoteListViewModel NoteListViewModel { get; }

        public BaseNoteViewModel CurrentNote { get; set; }

        public int CurrentNoteIndex => CurrentNote != null ? Notes.IndexOf(CurrentNote) : -1;

        public bool CurrentNoteExists => CurrentNote != null;

        public bool CanGoBack => CurrentNoteIndex > 0;

        public bool CanGoForward => CurrentNoteIndex != -1 && CurrentNoteIndex + 1 < Notes.Count;

        public string WindowTitle => "VSN" + (FileName != null ? " - " + FileName : null) + (CurrentNote != null ? " - " + CurrentNote.Name : null);

        public void Open()
        {
            var fileDialog = new OpenFileDialog {Filter = "XML File (*.xml)|*.xml"};
            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                CurrentNote = null;
                FilePath = fileDialog.FileName;
                FileName = fileDialog.SafeFileName;
                Notes = XmlUtils.LoadNotesFromXml(FilePath);
                Notes.CollectionChanged += NotesOnCollectionChanged;
            }
        }

        public void Save()
        {
            if (!string.IsNullOrEmpty(FilePath))
                XmlUtils.SaveNotesToXml(FilePath, Notes);

            else SaveAs();
        }

        public void SaveAs()
        {
            var fileDialog = new SaveFileDialog {Filter = "XML File (*.xml)|*.xml"};
            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                FilePath = fileDialog.FileName;
                FileName = fileDialog.SafeFileName;
                XmlUtils.SaveNotesToXml(FilePath, Notes);
            }
        }

        public void AddNote(object parameter)
        {
            if (parameter is NoteType noteType)
            {
                BaseNoteViewModel newNote = noteType.NewInstance();
                Notes.Add(newNote);
                CurrentNote = newNote;
            }
        }

        public void DeleteCurrentNote()
        {
            DeleteNoteAtIndex(CurrentNoteIndex);
        }

        public void DeleteNoteAtIndex(int noteIndex)
        {
            if (noteIndex > -1)
            {
                if (CurrentNote == Notes[noteIndex])
                    CurrentNote = noteIndex - 1 > -1 ? Notes[noteIndex - 1] : null;

                Notes.RemoveAt(noteIndex);
            }
        }

        private void NotesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(CanGoForward));
            OnPropertyChanged(nameof(CanGoBack));
        }

        public void PreviousNote()
        {
            if (CanGoBack)
                CurrentNote = Notes[CurrentNoteIndex - 1];
        }

        public void NextNote()
        {
            if (CanGoForward)
                CurrentNote = Notes[CurrentNoteIndex + 1];
        }
    }
}