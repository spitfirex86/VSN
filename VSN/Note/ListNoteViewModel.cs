using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using VSN.WPF;

namespace VSN.Note
{
    public class ListNoteViewModel : BaseNoteViewModel
    {
        public ListNoteViewModel(string name = null) : base(name)
        {
            AddItemCommand = new RelayCommand(AddItem);
            DeleteItemCommand = new RelayCommand(DeleteItem);
            CopyAsTextCommand = new RelayCommand(CopyAsText);

            Content = new ObservableCollection<ListNoteItem> { new ListNoteItem() };
        }

        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand CopyAsTextCommand { get; }

        public ObservableCollection<ListNoteItem> Content { get; set; }

        public bool Checkboxes { get; set; }

        public void AddItem()
        {
            Content.Add(new ListNoteItem());
        }

        public void DeleteItem(object parameter)
        {
            if (parameter is ListNoteItem item)
                Content.Remove(item);
        }

        public void CopyAsText()
        {
            string output = "";

            foreach (ListNoteItem item in Content)
            {
                string bullet = Checkboxes ? "- [" + (item.IsChecked ? "x" : " ") + "] " : "- ";
                output += bullet + item.Text + '\n';
            }

            Clipboard.SetText(output);
        }

        public override XElement GetXmlContent()
        {
            XElement element = new XElement("Content", new XAttribute("Checkboxes", Checkboxes));
            foreach (ListNoteItem item in Content)
                element.Add(new XElement("Item", new XAttribute("Checked", item.IsChecked), item.Text));

            return element;
        }

        public override void SetContentFromXml(XElement element)
        {
            Content = new ObservableCollection<ListNoteItem>();
            Checkboxes = element.Attribute("Checkboxes")?.Value.ToLower() == "true";

            foreach (XElement item in element.Elements())
            {
                Content.Add(new ListNoteItem
                {
                    IsChecked = item.Attribute("Checked")?.Value.ToLower() == "true",
                    Text = item.Value
                });
            }
        }

        public class ListNoteItem
        {
            public string Text { get; set; }

            public bool IsChecked { get; set; }
        }

    }
}