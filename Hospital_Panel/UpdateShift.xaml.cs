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

        public string GetNewDate()
        {
            tomsg = ShiftUpdate_Picker.SelectedDate.Value.ToString("d");
            //s.newshiftdate = tomsg;
            this.Close();
            return tomsg;
        }

        public void Update()
        {
            this.Show();
            
        }

        private void SaveUpdatedDate_Click(object sender, RoutedEventArgs e)
        {
            string selected_date = GetNewDate();
            //MessageBox.Show(selected_date);
            sh.Update_Date(selected_date);
        }
    }
}
