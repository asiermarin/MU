using MU.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MU.Test
{
    class CreadorCoordenadasU
    {
        public string CadenaRevisar { get; set; }

        private List<CoordenadasU> _listaCoordenadas;

        private List<int> _listaPrimerasU;

        public CreadorCoordenadasU()
        {
            _listaCoordenadas = new List<CoordenadasU>();
            _listaPrimerasU = new List<int>();

            CrearCoordenadas();
        }

        public List<CoordenadasU> DevolverListaCoordenadas()
        {
            return _listaCoordenadas;
        }

        public void LimpiarEnMemoria()
        {
            _listaCoordenadas.Clear();
            _listaPrimerasU.Clear();
        }

        private void CrearCoordenadas()
        {

        }
    }
}
