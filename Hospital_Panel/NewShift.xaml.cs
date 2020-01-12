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
    /// Interaction logic for NewShift.xaml
    /// </summary>
    public partial class NewShift : Window
    {
        static WorkersList list = new WorkersList();

        public NewShift()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            string text = null;
            list = MainWindow.Deserialize();
            ArrayList itemsList = new ArrayList();

            foreach (Pracownik record in list.ListOfWorkers)
            {
                if (record.Function == "Doctor" || record.Function == "Nurse")
                {
                    text = $"{record.GetFunction()} | {record.GetWorkerData()} ";
                    cb_WorkersList.Items.Add(text);
                }
            }

            //ListBox.ItemsSource = itemsList;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
