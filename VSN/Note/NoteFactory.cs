using System;
using System.Collections.Generic;
using System.Linq;
using VSN.WPF;

namespace VSN.Note
{
    public static class NoteFactory
    {
        static NoteFactory()
        {
            DataTemplateManager manager = new DataTemplateManager();
            foreach (NoteType noteType in NoteTypes) 
                manager.RegisterDataTemplate(noteType.NType, noteType.ViewType);
        }

        public static List<NoteType> NoteTypes = new List<NoteType>
        {
            new NoteType("PlainNote", "Plain Note",
                typeof(PlainNoteViewModel), typeof(PlainNoteView), () => new PlainNoteViewModel()),
            new NoteType("ListNote", "List Note", 
                typeof(ListNoteViewModel), typeof(ListNoteView), () => new ListNoteViewModel()),
        };

        public static Dictionary<string, NoteType> NoteTypesByName = NoteTypes.ToDictionary(x => x.Name);

        public static Dictionary<Type, NoteType> NoteTypesByType = NoteTypes.ToDictionary(x => x.NType);
    }
}