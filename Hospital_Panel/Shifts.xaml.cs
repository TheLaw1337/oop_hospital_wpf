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
using System.Windows.Shapes;
using System.Collections;
using Szpital_Pracownicy;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for Shifts.xaml
    /// </summary>
    public partial class Shifts : Window
    {
        MainWindow mw = new MainWindow();
        static WorkersList list = new WorkersList();
        public Shifts()
        {
            InitializeComponent();
            FillList();
        }

        private void AddShift_Click(object sender, RoutedEventArgs e)
        {
            NewShift ns = new NewShift();
            ns.Show();
        }

        private void FillList()
        {
            string text;
            list = MainWindow.Deserialize();
            ArrayList itemsList = new ArrayList();

            foreach (Pracownik record in list.ListOfWorkers)
            {

                text = $"{record.shift_list.Count} | {record.GetFunction()} | {record.GetWorkerData()} ";
                itemsList.Add(text);
            }

            ListBox.ItemsSource = itemsList;
        }
    }
}
