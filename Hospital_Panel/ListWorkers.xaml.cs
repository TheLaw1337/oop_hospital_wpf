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
using Szpital_Pracownicy;
using System.Collections;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for ListWorkers.xaml
    /// </summary>
    public partial class ListWorkers : Window
    {
        MainWindow mw = new MainWindow();
        static WorkersList list = new WorkersList();
        public ListWorkers()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            string text;
            list = MainWindow.Deserialize();
            ArrayList itemsList = new ArrayList();

            foreach (Pracownik record in list.ListOfWorkers)
            {

                text = $"{record.GetFunction()} | {record.GetWorkerData()} ";
                itemsList.Add(text);
            }

            ListBox.ItemsSource = itemsList;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            FillList();
        }
    }
}
