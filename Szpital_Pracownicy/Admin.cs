using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital_Pracownicy
{
    [Serializable()]
    public class Admin : Pracownik
    {
        //private string Function;

        public Admin()
        {

        }

        public Admin(string newName, string newSurname, long newPesel, string newPassword) : base(newSurname,newName,newPesel,newPassword)
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
