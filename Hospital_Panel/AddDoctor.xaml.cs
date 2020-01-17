using System.Windows;
using System.Windows.Input;
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