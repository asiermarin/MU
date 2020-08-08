using System;
using System.Collections.Generic;
using System.Text;

namespace MU.Modelos
{
    class CoordenadasIII
    {
        public int CoordenadaI { get; set; }
        public int CoordenadaII { get; set; }
        public int CoordenadaIII { get; set; }

        public bool YaUtilizada { get; set; }

        public CoordenadasIII(int coordenada1, int coordenada2, int coordenada3) 
        {
            CoordenadaI = coordenada1;
            CoordenadaII = coordenada2;
            CoordenadaIII = coordenada3;
            YaUtilizada = false;
        } 
    }
}