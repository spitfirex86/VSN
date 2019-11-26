using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Linq;
using VSN.Note;

namespace VSN.Utils
{
    public static class XmlUtils
    {
        public static void SaveNotesToXml(string filename, IEnumerable<BaseNoteViewModel> notes)
        {
            //TODO

            XElement xmlContainer = new XElement("Notes");

            foreach (BaseNoteViewModel note in notes)
            {
                if (note is PlainNoteViewModel plainNote)
                    xmlContainer.Add(new XElement("Note", new XElement("Name", plainNote.Name), new XElement("Type", 0), new XElement("Content", plainNote.Content)));
            }

            new XDocument(xmlContainer).Save(filename);
        }

        public static ObservableCollection<BaseNoteViewModel> LoadNotesFromXml(string filename)
        {
            //TODO

            if (!File.Exists(filename))
                return null;

            ObservableCollection<BaseNoteViewModel> notes = new ObservableCollection<BaseNoteViewModel>();

            var xml = XDocument.Load(filename);

            foreach (XElement element in xml.Element("Notes").Elements())
            {
                if (int.Parse(element.Element("Type").Value) == 0)
                {
                    notes.Add(new PlainNoteViewModel(element.Element("Name").Value, element.Element("Content").Value));
                }
            }

            return notes;
        }
    }
}