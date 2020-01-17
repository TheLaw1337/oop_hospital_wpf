using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital_Pracownicy
{
    [Serializable()]
    public class Nurse : Pracownik
    {
        //private string Function;
        //private static int Number;
        //private string No_num; // No. - liczba porządkowa
        private int Shifts;

        public Nurse()
        {
        }

        public Nurse(string newSurname, string newName, long newPesel, string newPassword) : base(newSurname, newName,
            newPesel, newPassword)
        {
            Number++;
            this.No_num = $"Nur. {Number.ToString()}";
            this.Function = "Nurse";
        }


        public override string GetWorkerData()
        {
            return $"{this.Surname}, {this.Name}, {this.Pesel}, {this.Username}";
        }
    }
}