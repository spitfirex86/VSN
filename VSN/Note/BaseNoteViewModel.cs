using System.Xml.Linq;
using VSN.WPF;

namespace VSN.Note
{
    public abstract class BaseNoteViewModel : BaseViewModel
    {
        protected BaseNoteViewModel(string name)
        {
            Name = name ?? "Untitled note";
        }

        public string Name { get; set; }

        public abstract XElement GetXmlContent();

        public abstract void SetContentFromXml(XElement element);
    }
}