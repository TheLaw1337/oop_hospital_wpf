using System;
using System.Collections.Generic;

namespace Szpital_Pracownicy
{
    [Serializable()]
    public class WorkersList
    {
        public List<Pracownik> ListOfWorkers = new List<Pracownik>();
    }
}