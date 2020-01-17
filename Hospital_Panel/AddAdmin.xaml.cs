using System.Windows;
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