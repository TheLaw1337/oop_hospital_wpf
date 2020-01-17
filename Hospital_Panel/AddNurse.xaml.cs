using System.Windows;
using Szpital_Pracownicy;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for AddNurse.xaml
    /// </summary>
    public partial class AddNurse : Window
    {
        MainWindow mw = new MainWindow();

        public AddNurse()
        {
            InitializeComponent();
        }

        private void SaveNewNurse(object sender, RoutedEventArgs e)
        {
            Pracownik p = new Nurse(txtSurname.Text, txtName.Text, long.Parse(txtPesel.Text), passwordBox.Password);
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
    }
}