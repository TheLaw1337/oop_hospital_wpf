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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int index = ListBox.Items.IndexOf(ListBox.SelectedItem);
            MessageBoxResult result =
                MessageBox.Show($"Are you sure to delete the user '{list.ListOfWorkers[index].Username}'?",
                    "Please confirm", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:

                    mw.Remove(index);
                    break;
                case MessageBoxResult.No:
                    break;
            }

            FillList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int index = ListBox.Items.IndexOf(ListBox.SelectedItem);
            string surname, name;
            long pesel;
            surname = list.ListOfWorkers[index].Surname;
            name = list.ListOfWorkers[index].Name;
            pesel = list.ListOfWorkers[index].Pesel;
            string function = list.ListOfWorkers[index].GetFunction();

            switch (function)
            {
                case "Doctor":
                {
                    AddDoctor ad = new AddDoctor();

                    //string temp_no_num = list.ListOfWorkers[index].No_num;
                    mw.Remove(index);
                    ad.Update(surname, name, pesel.ToString());

                    break;
                }
                case "Nurse":
                {
                    AddNurse an = new AddNurse();

                    //string temp_no_num = list.ListOfWorkers[index].No_num;
                    mw.Remove(index);
                    an.Update(surname, name, pesel.ToString());

                    break;
                }
                case "Administrator":
                {
                    AddAdmin aa = new AddAdmin();
                    mw.Remove(index);
                    aa.Update(surname, name, pesel.ToString());

                    break;
                }
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}