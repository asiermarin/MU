using System;
using System.Collections.Generic;
using System.Text;

namespace MU.Modelos
{
    class Mu
    {
        public bool EsMu { get; set; }

        public string Cadena { get; set; }

        public string UltimaRegla { get; set; }

        public bool ContieneIII { get; set; }

        public List<string> Historial { get; set; }

        public Mu(string cadenaInicial, string ultimaRegla/*, List<string> historial*/)
        {
            Cadena = cadenaInicial;
            UltimaRegla = ultimaRegla;
            ContieneIII = false;

            /*
            Historial = new List<string>(); 
            Historial =  historial;
            Historial.Add(UltimaRegla);
            */

            ComprobarMu();
        }

        private void ComprobarMu()
        {
            if(Cadena == "Mu")
            {
                EsMu = true;
            }
            else 
            {
                EsMu = false;
            }
        }
    }
}
