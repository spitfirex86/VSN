namespace VSN.Note
{
    public class BaseNoteViewModel
    {
        public BaseNoteViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}