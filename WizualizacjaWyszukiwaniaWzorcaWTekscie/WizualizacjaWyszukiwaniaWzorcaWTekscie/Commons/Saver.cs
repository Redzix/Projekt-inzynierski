//Save patternlength, rangel, searchtime, result count
//save/logger delta
//if !saverenabled to nie mozna zapisywac
//sprawdzic czy juz było wczesniej to samo zapisane
//nie nadpisywac
//nie zapisywac, kiedy pusty

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using EngineeringProject.Enum;

namespace EngineeringProject.Commons
{
    class Saver
    {
        private bool saveEnabled = false;

        public Saver()
        {
            CheckDirectory();
        }

        private void CheckDirectory()
        {
            if (!Directory.Exists(Path.GetDirectoryName("Results")))
                CreateDirectory("Results");
           // CreateFile("Results\\text.txt");

            saveEnabled = true;
        }

        private void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        private void CreateFile(string path)
        {
            File.CreateText(path);
           
        }

        public bool SaveResults(int rangeLength, int patternLegth, int count, long time, ESearchMethods method)
        {
            if (File.Exists("Results\\text.txt"))
            {
                using (StreamWriter write = new StreamWriter("Results\\text.txt"))
                {
                    write.WriteLine(method.ToString() + "," + rangeLength + "," + patternLegth + "," + count + "," + time);
                }
                return true;
            }
            else
            {
                return false;
                //todo
            }
        }
    }
}
