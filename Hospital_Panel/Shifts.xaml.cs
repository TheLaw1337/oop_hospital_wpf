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
        NewShift ns = new NewShift();
        public Shifts()
        {
            InitializeComponent();
            FillList();
            //MessageBox.Show(mw.loggeduser_function);
            //ButtonFilter();
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

        public void ButtonFilter()
        {
            
            if (mw.loggeduser_function.Equals("Doctor") || mw.loggeduser_function.Equals("Nurse"))
            {
                AddShift.IsEnabled = false;
                Refresh.IsEnabled = false;
                UpdateShift.IsEnabled = false;
                DeleteShift.IsEnabled = false;
            }
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
            if (ListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Select the shift first!");
            }
            else
            {
                UpdateShift us = new UpdateShift(this);
                us.Update();
                //MessageBox.Show(newshiftdate);
            }
        }

        public void Update_Date(string d)
        {
            object test = cb_ShiftWorkersList.SelectedItem;
            string selected_listbox = ListBox.SelectedItem.ToString();
            bool val_result;
            bool failed = false;

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
                        val_result = ns.ShiftValidate(record.shift_list, new_date);
                        if (val_result.Equals(false))
                        {
                            MessageBox.Show("Can't update shift - 1 or 2 validation criterias failed\n1) Max 10 shifts in month\n2) Two or more cardiologist/urologist/etc. can't have shift at the same day");
                            failed = true;
                        }
                        else
                        {
                            item.date = new_date;
                            mw.Serialize_NewShift(list);
                            //done = true;
                            break;
                        }
                        if (failed)
                        {
                            break;
                        }
                    }
                    //if (done.Equals(true))
                    //{
                    //    break;
                    //}
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.SelectedIndex < 0)
            {
                MessageBox.Show("Select the shift first!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure to delete this shift?", "Confirm delete operation", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        DeleteDate();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }
        public void DeleteDate()
        {
            string cb_text;
            object test = cb_ShiftWorkersList.SelectedItem;
            int selected_listbox = ListBox.SelectedIndex;
            foreach (var record in list.ListOfWorkers)
            {
                cb_text = $"Shifts: {record.shift_list.Count} | {record.GetFunction()} | {record.GetWorkerData()} ";
                if (cb_text.Equals(test))
                {
                    record.shift_list.RemoveAt(selected_listbox);
                }
            }
            mw.Serialize_NewShift(list);
        }
    }
}
