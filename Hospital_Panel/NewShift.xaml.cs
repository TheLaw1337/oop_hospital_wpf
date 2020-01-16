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
        MainWindow mw = new MainWindow();
        DateTime new_shiftdate;
        
        public NewShift()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            string text = null;
            list = MainWindow.Deserialize();
            //ArrayList itemsList = new ArrayList();

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

        private void SaveShift_Click(object sender, RoutedEventArgs e)
        {
            int index = cb_WorkersList.SelectedIndex;
            DateTime shiftDate = DatePick.SelectedDate.Value.Date;
            bool val_result;

            //list.ListOfWorkers[index].shift_list.Add(shiftDate);
            //mw.Serialize();

            //int index = ListBox.Items.IndexOf(ListBox.SelectedItem);
            string surname, name;
            long pesel;
            surname = list.ListOfWorkers[index].Surname;
            name = list.ListOfWorkers[index].Name;
            pesel = list.ListOfWorkers[index].Pesel;
            string function = list.ListOfWorkers[index].GetFunction();
            List<Shift> shiftlist = list.ListOfWorkers[index].shift_list;
            val_result = ShiftValidate(shiftlist, shiftDate);

            if (val_result.Equals(false))
            {
                MessageBox.Show("Too many shifts");
            }
            else
            {
                Shift nshift = new Shift();
                nshift.id = shiftlist.Count + 1;
                nshift.date = shiftDate;
                shiftlist.Add(nshift);

                foreach (Pracownik record in list.ListOfWorkers)
                {
                    if (record.Pesel.Equals(pesel))
                    {
                        record.shift_list = shiftlist;
                        mw.Serialize_NewShift(list);
                    }
                }
                this.Close();
            }
        }

        public DateTime Update(int i, string d) {
            
            this.Show();
            cb_WorkersList.SelectedIndex = i;
            cb_WorkersList.IsEnabled = false;
            DateTime shiftdate = Convert.ToDateTime(d);
            DatePick.SelectedDate = shiftdate;

            return new_shiftdate;
        }

        public bool ShiftValidate(List<Shift> l, DateTime newdate)
        {
            int month = newdate.Month;
            int count = 0;
            bool val_ok = false;

            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].date.Month.Equals(month))
                {
                    count++;
                }
            }

            if (count < 10)
            {
                val_ok = true;
            }
            return val_ok;
            
        }
    }
}
