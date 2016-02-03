using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using ChangeTime.Props;

namespace ChangeTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string filePath;
        public string FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                OnPropertyChanged("FilePath");
            }
        }
        public string xmlkey;
        public string xmlKey
        {
            get { return xmlkey; }
            set
            {
                xmlkey = value;
                OnPropertyChanged("xmlKey");
            }
        }
        public string xmlvalue;
        public string xmlValue
        {
            get { return xmlvalue; }
            set
            {
                xmlvalue = value;
                OnPropertyChanged("xmlValue");
            }
        }

        public string xmlskills;
        public string xmlSkills
        {
            get { return xmlskills; }
            set
            {
                xmlskills = value;
                OnPropertyChanged("xmlSkills");
            }
        }

        public ObservableCollection<SearchValues> possibleSearchValues { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            FilePath = @"C:\Game Server\Lineage II Highfive\game\data\stats\skills";
            xmlKey = "abnormalTime";
            possibleSearchValues = new ObservableCollection<SearchValues>();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                var allSkills = xmlSkills?.Trim().Split(',');
                var files = Directory.GetFiles(FilePath);
                for (int i = 0; i < allSkills.Length; i++)
                {
                    for (int j = 0; j < files.Length; j++)
                    {
                        var numbers = System.IO.Path.GetFileNameWithoutExtension(files[j]).Split('-');
                        if (int.Parse(allSkills[i]) >= int.Parse(numbers[0]) && int.Parse(allSkills[i]) <= int.Parse(numbers[1]))
                        {
                            List overview;
                            using (StreamReader file = new StreamReader(files[j]))
                            {
                                XmlSerializer reader = new XmlSerializer(typeof(List));
                                overview = (List)reader.Deserialize(file);


                                foreach (var skill in overview.Skill)
                                {
                                    if (skill.Id == allSkills[i])
                                    {
                                        foreach (var item in skill.Set)
                                            if (item.Name == xmlKey) item.Val = xmlValue;
                                    }
                                }
                            }

                            using (var wfile = new StreamWriter(files[j]))
                            {
                                XmlSerializer x = new XmlSerializer(overview?.GetType());
                                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                                ns.Add("", "");
                                x.Serialize(wfile, overview, ns);
                            };
                        }
                    }
                }

                MessageBox.Show("Files are now updated!");
            }
            catch (XmlException ex)
            {
                MessageBox.Show("Something is wrong with the XML or FilePath, FIX IT!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
