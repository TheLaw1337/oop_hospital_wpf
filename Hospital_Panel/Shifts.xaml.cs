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
        public string newshiftdate;
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
            //ArrayList itemsList = new ArrayList();

            foreach (Pracownik record in list.ListOfWorkers)
            {

                text = $"Shifts: {record.shift_list.Count} | {record.GetFunction()} | {record.GetWorkerData()} ";
                //itemsList.Add(text);
                cb_ShiftWorkersList.Items.Add(text);
            }

            //ListBox.ItemsSource = itemsList;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            cb_ShiftWorkersList.Items.Clear();
            FillList();
        }

        private void cb_ShiftWorkersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object test = cb_ShiftWorkersList.SelectedItem;

            string text;
            list = MainWindow.Deserialize();
            //ArrayList itemsList = new ArrayList();

            foreach (Pracownik record in list.ListOfWorkers)
            {
                text = $"Shifts: {record.shift_list.Count} | {record.GetFunction()} | {record.GetWorkerData()} ";
                if (text.Equals(test))
                {
                    ListBox.Items.Clear();
                    
                    //ListBox.ItemsSource = record.shift_list;

                foreach (var item in record.shift_list)
                    {
                        string to_display = $"{item.id} | {item.date.ToShortDateString()}";
                        ListBox.Items.Add(to_display);
                    }
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            //int index = cb_ShiftWorkersList.SelectedIndex;
            //string date = ListBox.SelectedItem.ToString();



            //NewShift ns = new NewShift();
            //ns.Update(index, date);
            UpdateShift us = new UpdateShift(this);
            us.Update();
            //MessageBox.Show(newshiftdate);
        }

        public void Update_Date(string d)
        {
            object test = cb_ShiftWorkersList.SelectedItem;
            string selected_listbox = ListBox.SelectedItem.ToString();

            string text;
            list = MainWindow.Deserialize();

            foreach (var record in list.ListOfWorkers)
            {
                text = $"Shifts: {record.shift_list.Count} | {record.GetFunction()} | {record.GetWorkerData()} ";
                if (text.Equals(test))
                {
                    foreach (var item in record.shift_list)
                    {
                        string to_compare = $"{item.date.ToShortDateString()}";
                        DateTime new_date = Convert.ToDateTime(d);
                        item.date = new_date;
                        mw.Serialize_NewShift(list);
                        break;
                        //if (to_compare.Equals(d))
                        //{
                        //    MessageBox.Show($"Old date: to_compare\nfdsfsfdsfs");
                        //}
                    }
                }
            }
        }
    }
}
