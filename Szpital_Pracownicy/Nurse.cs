using System;

namespace Szpital_Pracownicy
{
    [Serializable()]
    public class Nurse : Pracownik
    {
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