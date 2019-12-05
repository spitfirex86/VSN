using System;

namespace VSN.Note
{
    public class NoteType
    {
        public NoteType(string name, string displayName, Type type, Type viewType, Func<BaseNoteViewModel> newInstance)
        {
            Name = name;
            DisplayName = displayName;
            NType = type;
            ViewType = viewType;
            NewInstance = newInstance;
        }

        public string Name { get; }

        public string DisplayName { get; }

        public Type NType { get; }

        public Type ViewType { get; }

        public Func<BaseNoteViewModel> NewInstance { get; }
    }
}