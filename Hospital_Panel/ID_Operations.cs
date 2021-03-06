﻿using System;
using System.IO;

namespace Hospital_Panel
{
    public class ID_Operations
    {
        public ID_Operations(String filename)
        {
        }

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