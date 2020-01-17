using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital_Pracownicy
{
    [Serializable()]
    public class WorkersList
    {
        public List<Pracownik> ListOfWorkers = new List<Pracownik>();
    }
}