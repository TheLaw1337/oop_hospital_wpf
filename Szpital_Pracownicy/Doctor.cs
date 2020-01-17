using System;


namespace Szpital_Pracownicy
{
    [Serializable()]
    public class Doctor : Pracownik
    {
        public string Specialty;

        public int PWZnumber;

        private int Shifts;

        public Doctor()
        {
        }

        public Doctor(string newSurname, string newName, long newPesel, string newSpecialty, int newPWZnumber,
            string newPassword) : base(newSurname, newName, newPesel, newPassword)
        {
            Number = Number + 1;
            No_num = $"Doc. {Number.ToString()}";
            this.Specialty = newSpecialty;
            this.PWZnumber = newPWZnumber;
            this.Function = "Doctor";
        }

        public override string GetWorkerData()
        {
            return $"{this.Surname}, {this.Name}, {this.Pesel}, {this.Specialty}, {this.PWZnumber}, {this.Username}";
        }
    }
}