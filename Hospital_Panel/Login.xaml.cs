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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Szpital_Pracownicy;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static List<Pracownik> workers = new List<Pracownik>();
        public static WorkersList workersList = Deserialize();
        public string loggeduser_function;
        
        public Login()
        {
            InitializeComponent();
            
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool login_result = false;
            foreach (var record in workersList.ListOfWorkers)
            {
                if (record.Username.Equals(login_field.Text) && record.Password.Equals(passwordBox.Password))
                {
                    login_result = true;
                    loggeduser_function = record.Function;
                }
                
            }
            if (login_result)
            {
                MainWindow mw = new MainWindow(this);
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong login and/or password");
            }
        }

        public static WorkersList Deserialize()
        {
            WorkersList list = new WorkersList();
            BinaryFormatter binary = new BinaryFormatter();

            if (File.Exists("hospital_data.dat"))
            {
                using (Stream fstream = new FileStream("hospital_data.dat", FileMode.Open, FileAccess.Read))
                {
                    list = (WorkersList)binary.Deserialize(fstream);
                }
            }
            else
            {
                List<Pracownik> newList = new List<Pracownik>();
                list.ListOfWorkers = newList;
                //Console.WriteLine("List not found - new list created, will be saved during exit");
            }
            return list;
        }

    }
}
