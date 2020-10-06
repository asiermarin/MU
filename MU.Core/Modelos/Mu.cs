using System;
using System.Collections.Generic;
using System.Text;

namespace MU.Modelos
{
    public class Mu
    {
        public bool EsMu { get; set; }

        public string Cadena { get; set; }

        public string UltimaRegla { get; set; }

        public bool ContieneIII { get; set; }

        public List<string> Historial { get; set; }

        public bool ContieneU { get; set; }

        public bool Limpiar { get; set; }

        public Mu(string cadenaInicial, string ultimaRegla, List<string> historial)
        {
            Cadena = cadenaInicial;
            UltimaRegla = ultimaRegla;
            ContieneIII = false;
            ContieneU = false;

            ReplicarHisotorial(historial);
            Historial.Add(UltimaRegla);
            
            ComprobarMu();
        }

        private void ComprobarMu()
        {
            if(Cadena == "MU")
            {
                EsMu = true;
            }
            else 
            {
                EsMu = false;
            }
        }

        private void ReplicarHisotorial(List<string> historial)
        {
            Historial = new List<string>();
            Historial.AddRange(historial);
        }
    }
}
