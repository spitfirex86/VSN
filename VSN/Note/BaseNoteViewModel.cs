namespace VSN.Note
{
    public class BaseNoteViewModel
    {
        public BaseNoteViewModel(string name)
        {
            Name = name ?? "Untitled note";
        }

        public string Name { get; set; }
    }
}