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

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for AddAdmin.xaml
    /// </summary>
    public partial class AddAdmin : Window
    {
        MainWindow mw = new MainWindow();

        public AddAdmin()
        {
            InitializeComponent();
        }

        private void SaveNewAdmin(object sender, RoutedEventArgs e)
        {
            Pracownik p = new Admin(txtSurname.Text, txtName.Text, long.Parse(txtPesel.Text), passwordBox.Password);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}