using System;
using System.Collections.Generic;
using System.Linq;

namespace VSN.Note
{
    public static class NoteFactory
    {
        public static List<NoteType> NoteTypes = new List<NoteType>
        {
            new NoteType("PlainNote", "Plain Note", typeof(PlainNoteViewModel), () => new PlainNoteViewModel()),
            //new NoteType("MultiNote", "Multi Note", null, () => throw new NotImplementedException())
        };

        public static Dictionary<string, NoteType> NoteTypesByName = NoteTypes.ToDictionary(x => x.Name);

        public static Dictionary<Type, NoteType> NoteTypesByType = NoteTypes.ToDictionary(x => x.NType);
    }
}