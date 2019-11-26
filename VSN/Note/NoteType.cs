using System;

namespace VSN.Note
{
    public class NoteType
    {
        public NoteType(string name, Func<BaseNoteViewModel> newInstance)
        {
            Name = name;
            NewInstance = newInstance;
        }

        public string Name { get; }

        public Func<BaseNoteViewModel> NewInstance { get; }
    }
}