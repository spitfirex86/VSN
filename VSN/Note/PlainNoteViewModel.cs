namespace VSN.Note
{
    public class PlainNoteViewModel : BaseNoteViewModel
    {
        public PlainNoteViewModel(string name, string content) : base(name)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}