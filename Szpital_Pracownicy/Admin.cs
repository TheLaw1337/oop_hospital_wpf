using System;

namespace Szpital_Pracownicy
{
    [Serializable()]
    public class Admin : Pracownik
    {
        public Admin()
        {
        }

        public Admin(string newSurname, string newName, long newPesel, string newPassword) : base(newSurname, newName,
            newPesel, newPassword)
        {
            Number++;
            this.No_num = $"Adm. {Number.ToString()}";
            this.Function = "Administrator";
        }

        public override string GetWorkerData()
        {
            return $"{this.Surname}, {this.Name}, {this.Pesel}, {this.Username}";
        }
    }
}