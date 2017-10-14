using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektInzynierski.Controller
{
    class AlgorytmNaive
    {
        
        public List<int> SzukajWzorca(string wzorzec,string zakres)
        {
          
            List<int> listaWynikow = new List<int>();
            for(int i = 0; i < (zakres.Length - wzorzec.Length + 1); i++)
            {
                if (wzorzec.Equals(zakres.Substring(i, wzorzec.Length)))
                    listaWynikow.Add(i);

            }
            return listaWynikow;
        }
    
    }
}
