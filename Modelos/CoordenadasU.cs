using System;
using System.Collections.Generic;
using System.Text;

namespace MU.Modelos
{
    class CoordenadasU
    {
        public int CoordenadaPrimera { get; set; }

        public int CoordenadaUltima { get; set; }

        public bool YaUtilizada { get; set; }

        public CoordenadasU(int coordenadaPrimera, int coordenadaUltima)
        {
            CoordenadaPrimera = coordenadaPrimera;
            CoordenadaUltima = coordenadaUltima;

            YaUtilizada = false;
        }
    }
}
