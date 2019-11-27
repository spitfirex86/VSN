using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using VSN.Note;

namespace VSN.Utils
{
    public static class XmlUtils
    {
        //TODO: Handle XML parse errors

        public static void SaveNotesToXml(string filename, IEnumerable<BaseNoteViewModel> notes)
        {
            XElement xmlContainer = new XElement("Notes");

            foreach (BaseNoteViewModel note in notes)
            {
                if (NoteFactory.NoteTypesByType.TryGetValue(note.GetType(), out NoteType noteType))
                    xmlContainer.Add(new XElement(noteType.Name, new XAttribute("Name", note.Name), note.GetXmlContent()));
            }

            new XDocument(xmlContainer).Save(filename);
        }

        public static ObservableCollection<BaseNoteViewModel> LoadNotesFromXml(string filename)
        {
            if (!File.Exists(filename))
                return null;

            ObservableCollection<BaseNoteViewModel> notes = new ObservableCollection<BaseNoteViewModel>();

            var xml = XDocument.Load(filename);

            foreach (XElement element in xml.Element("Notes").Elements())
            {
                if (NoteFactory.NoteTypesByName.TryGetValue(element.Name.LocalName, out NoteType noteType))
                {
                    BaseNoteViewModel note = noteType.NewInstance();

                    note.Name = element.Attribute("Name").Value;
                    note.SetContentFromXml(element.Elements().First());

                    notes.Add(note);
                }
            }

            return notes;
        }
    }
}