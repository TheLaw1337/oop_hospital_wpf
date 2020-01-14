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
        DateTime dateToChange;
        Shifts s = new Shifts();
        public string tomsg;
        public UpdateShift()
        {
            InitializeComponent();
        }

        public void GetNewDate(object sender, SelectionChangedEventArgs e)
        {
            tomsg = ShiftUpdate_Picker.SelectedDate.Value.ToString("d");
            //s.newshiftdate = tomsg;
            this.Close();
            
        }

        public string Update()
        {
            this.Show();
            return tomsg;
        }
        
    }
}
