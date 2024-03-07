using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notatki
{
    class Notatka
    {
        public string tytul = "";
        public string tresc = "";   

        public Notatka(string tytul, string tresc)
        {
            this.tytul= tytul;
            this.tresc= tresc;  
        }
    }
}
