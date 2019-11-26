namespace VSN.Note
{
    public class PlainNoteViewModel : BaseNoteViewModel
    {
        public PlainNoteViewModel(string name = null, string content = null) : base(name)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}