using System.Xml.Linq;

namespace VSN.Note
{
    public class PlainNoteViewModel : BaseNoteViewModel
    {
        public PlainNoteViewModel(string name = null, string content = null) : base(name)
        {
            Content = content;
        }

        public string Content { get; set; }

        public override XElement GetXmlContent() => new XElement("Content", Content);

        public override void SetContentFromXml(XElement element) => Content = element.Value;
    }
}