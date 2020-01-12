using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Szpital_Pracownicy;

namespace Hospital_Panel
{
    public class ID_Operations
    {
        public ID_Operations(String filename) { }
        //public void SaveID(string path)
        //{
        //    using (StreamWriter plik = new StreamWriter(path))
        //    {
        //        //plik.WriteLine(Doctor.Number);
        //    }
        //}

        public int GetID(string path)
        {
            int id = 0;
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    id = int.Parse(file.ReadLine());
                }
            }
            return id;
        }

        public int NextID(string path)
        {
            int to_add = 0;
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    to_add = int.Parse(file.ReadLine());
                }
            }
            to_add++;
            using (StreamWriter plik = new StreamWriter(path))
            {
                plik.WriteLine(to_add);
            }

            return to_add;
        }
    }
}
