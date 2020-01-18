using System;
using System.Windows;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for UpdateShift.xaml
    /// </summary>
    public partial class UpdateShift : Window
    {
        Shifts sh = new Shifts();
        DateTime dateToChange;
        Shifts s = new Shifts();
        public string tomsg;

        public UpdateShift()
        {
            InitializeComponent();
        }

        public UpdateShift(Shifts sh)
        {
            InitializeComponent();
            this.sh = sh;
        }

        public string GetNewDate()
        {
            tomsg = ShiftUpdate_Picker.SelectedDate.Value.ToString("d");
            return tomsg;
        }

        public void Update()
        {
            this.Show();
        }

        private void SaveUpdatedDate_Click(object sender, RoutedEventArgs e)
        {
            string selected_date = GetNewDate();
            string selected_listbox = sh.ListBox.SelectedItem.ToString();
            sh.Update_Date(selected_date);
            this.Close();
        }
    }
}