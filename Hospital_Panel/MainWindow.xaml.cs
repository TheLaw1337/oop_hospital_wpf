﻿using System.Collections.Generic;
using System.Windows;
using Szpital_Pracownicy;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hospital_Panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Pracownik> workers = new List<Pracownik>();
        public static WorkersList workersList = Deserialize();

        Login log = new Login();
        public string loggeduser_function;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Login l)
        {
            InitializeComponent();
            this.log = l;
            loggeduser_function = log.loggeduser_function;
            Button_Filter();
        }

        private void Button_Filter()
        {
            if (loggeduser_function.Equals("Doctor") || loggeduser_function.Equals("Nurse"))
            {
                this.DoctorAdd.IsEnabled = false;
                this.NurseAdd.IsEnabled = false;
                this.AdminAdd.IsEnabled = false;
            }
        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddDoctor nd = new AddDoctor();
            nd.Show();
        }

        private void AddNurse_Click(object sender, RoutedEventArgs e)
        {
            AddNurse nn = new AddNurse();
            nn.Show();
        }
        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddAdmin aa = new AddAdmin();
            aa.Show();
        }

        private void ShowWorkers_Click(object sender, RoutedEventArgs e)
        {
            ListWorkers lw = new ListWorkers();
            if (this.loggeduser_function.Equals("Doctor") || this.loggeduser_function.Equals("Nurse"))
            {
                lw.UpdateWorker.IsEnabled = false;
                lw.Refresh.IsEnabled = false;
                lw.DeleteWorker.IsEnabled = false;
            }
            lw.Show();
        }

        private void Shifts_Click(object sender, RoutedEventArgs e)
        {
            Shifts sh = new Shifts();
            if (this.loggeduser_function.Equals("Doctor") || this.loggeduser_function.Equals("Nurse"))
            {
                sh.AddShift.IsEnabled = false;
                sh.Refresh.IsEnabled = false;
                sh.UpdateShift.IsEnabled = false;
                sh.DeleteShift.IsEnabled = false;
            }
            sh.Show();
        }

        public static WorkersList Deserialize()
        {
            WorkersList list = new WorkersList();
            BinaryFormatter binary = new BinaryFormatter();

            if (File.Exists("hospital_data.dat"))
            {
                using (Stream fstream = new FileStream("hospital_data.dat", FileMode.Open, FileAccess.Read))
                {
                    list = (WorkersList) binary.Deserialize(fstream);
                }
            }
            else
            {
                List<Pracownik> newList = new List<Pracownik>();
                list.ListOfWorkers = newList;
                MessageBox.Show("List not found - new list created, will be saved during this session");
            }
            return list;
        }

        public static void Serialize(WorkersList l)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream fStream = new FileStream("hospital_data.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fStream, l);
            }
        }

        public void Add(Pracownik pracownik)
        {
            workersList.ListOfWorkers.Add(pracownik);
            Serialize(workersList);
        }

        public void Remove(int worker_id)
        {
            workersList.ListOfWorkers.RemoveAt(worker_id);
            Serialize(workersList);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        public void Serialize_NewShift(WorkersList l)
        {
            Serialize(l);
        }
    }
}