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
using Szpital_Pracownicy;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Pracownik> workers = new List<Pracownik>();
        public static WorkersList workersList = Deserialize();
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddDoctor nd = new AddDoctor();
            nd.Show();
        }

        private void AddNurse_Click(object sender, RoutedEventArgs e)
        {
            AddNurse nn = new AddNurse();
            nn.Show();
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddAdmin aa = new AddAdmin();
            aa.Show();
        }

        private void ShowWorkers_Click(object sender, RoutedEventArgs e)
        {
            ListWorkers lw = new ListWorkers();
            lw.Show();
        }

        private void Shifts_Click(object sender, RoutedEventArgs e)
        {
            Shifts sh = new Shifts();
            sh.Show();
        }

        public static WorkersList Deserialize()
        {
            WorkersList list = new WorkersList();
            BinaryFormatter binary = new BinaryFormatter();

            if (File.Exists("hospital_data.dat"))
            {
                using (Stream fstream = new FileStream("hospital_data.dat", FileMode.Open, FileAccess.Read))
                {
                    list = (WorkersList)binary.Deserialize(fstream);
                }
            }
            else
            {
                List<Pracownik> newList = new List<Pracownik>();
                list.ListOfWorkers = newList;
                //Console.WriteLine("List not found - new list created, will be saved during exit");
            }
            return list;
        }

        public static void Serialize(WorkersList l)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream fStream = new FileStream("hospital_data.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fStream, l);
            }
        }

        public void Add(Pracownik pracownik)
        {
            workersList.ListOfWorkers.Add(pracownik);
            Serialize(workersList);
        }

        public void Remove(int worker_id)
        {
            workersList.ListOfWorkers.RemoveAt(worker_id);
            Serialize(workersList);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Dispatcher.InvokeShutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Serialize_NewShift(WorkersList l)
        {
            Serialize(l);
        }
    }
}
