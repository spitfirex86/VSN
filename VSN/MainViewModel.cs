using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
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

            NoteListViewModel = new NoteListViewModel(this);

            OpenCommand = new RelayCommand(Open);
            SaveCommand = new RelayCommand(Save);
            AddNoteCommand = new RelayCommand(AddNote);
            DeleteCurrentNoteCommand = new RelayCommand(DeleteCurrentNote);
        }

        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand AddNoteCommand { get; }
        public ICommand DeleteCurrentNoteCommand { get; }

        public ObservableCollection<BaseNoteViewModel> Notes { get; set; }

        public NoteListViewModel NoteListViewModel { get; }

        public BaseNoteViewModel CurrentNote { get; set; }

        public bool CurrentNoteExists => CurrentNote != null;

        public string WindowTitle => CurrentNote != null ? "VSN - " + CurrentNote.Name : "VSN";

        public void Open()
        {
            Notes = XmlUtils.LoadNotesFromXml("notes.xml");
        }

        public void Save()
        {
            XmlUtils.SaveNotesToXml("notes.xml", Notes);
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
            int noteIndex = Notes.IndexOf(CurrentNote);
            DeleteNoteAtIndex(noteIndex);
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
    }
}