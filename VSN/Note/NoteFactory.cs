using System;
using System.Collections.Generic;

namespace VSN.Note
{
    public static class NoteFactory
    {
        public static List<NoteType> NoteTypes = new List<NoteType>
        {
            new NoteType("Plain Note", () => new PlainNoteViewModel()),
            new NoteType("Multi Note", () => throw new NotImplementedException())
        };
    }
}