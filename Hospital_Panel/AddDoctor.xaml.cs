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
using System.Text.RegularExpressions;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for AddDoctor.xaml
    /// </summary>
    public partial class AddDoctor : Window
    {
        MainWindow mw = new MainWindow();
        static ID_Operations id_ops = new ID_Operations("NR_Doc.txt");
        static string path = "NR_Doc.txt";

        public AddDoctor()
        {
            InitializeComponent();
        }

        private void SaveNewDoctor(object sender, RoutedEventArgs e)
        {
            Pracownik p = new Doctor(txtSurname.Text, txtName.Text, long.Parse(txtPesel.Text), cb_Spec.Text,
                int.Parse(txtPWZ.Text), passwordBox.Password);
            //p.Number = id_ops.NextID(path);
            //p.No_num = $"Doc. {p.Number.ToString()}";
            mw.Add(p);
            this.Close();
        }

        public void Update(string surname, string name, string pesel)
        {
            this.Show();
            txtSurname.Text = surname;
            txtName.Text = name;
            txtPesel.Text = pesel;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}