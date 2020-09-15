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

        private List<int> _listaNumeroIntermedioEntreU;

        private List<int> _listaUltimasU;

        public CreadorCoordenadasU()
        {
            _listaCoordenadas = new List<CoordenadasU>();
            _listaPrimerasU = new List<int>();
            _listaUltimasU = new List<int>();
            _listaNumeroIntermedioEntreU = new List<int>();
        }

        public List<CoordenadasU> DevolverListaCoordenadas()
        {
            return _listaCoordenadas;
        }

        public void LimpiarEnMemoria()
        {
            _listaCoordenadas.Clear();
            _listaPrimerasU.Clear();
            _listaNumeroIntermedioEntreU.Clear();
            _listaUltimasU.Clear(); 
        }

        public void CrearCoordenadas()
        {
            int recuentosU = 0;
            for (int i = 1; i < CadenaRevisar.Length; i++)
            {
                if (i + 1 < CadenaRevisar.Length)
                {
                    if (IsFirstU(i - 1, i, i + 1))
                    {
                        _listaPrimerasU.Add(i);
                        recuentosU = 0;
                    }
                    else if (IsIntermediateU(i - 1, i, i + 1))
                    {
                        recuentosU++;
                    } 
                    else if (IsLastU(i - 1, i, i + 1))
                    {
                        recuentosU++;
                        _listaUltimasU.Add(i);
                        _listaNumeroIntermedioEntreU.Add(recuentosU);
                    }

                } else 
                {
                    if (IsLastUAndLetter(i - 1, i))
                    {
                        recuentosU++;
                        _listaUltimasU.Add(i);
                        _listaNumeroIntermedioEntreU.Add(recuentosU);
                    }
                }
            }

            RecorrerListas();
        }

        private bool IsFirstU(int previusCharDirection, int thisCharDirection, int nextCharDirection)
        {
            bool isFirstU = false;

            if (_listaPrimerasU != null)
            {
                if (CadenaRevisar[previusCharDirection] != 'U' &&
                    CadenaRevisar[thisCharDirection] == 'U' &&
                    CadenaRevisar[nextCharDirection] == 'U')
                {
                    isFirstU = true;
                }
            }

            return isFirstU;
        }

        private bool IsIntermediateU(int previusCharDirection, int thisCharDirection, int nextCharDirection)
        {
            bool isIntermediateU = false;

            if (_listaPrimerasU != null)
            {
                if (CadenaRevisar[previusCharDirection] == 'U' &&
                    CadenaRevisar[thisCharDirection] == 'U' &&
                    CadenaRevisar[nextCharDirection] == 'U')
                {

                    isIntermediateU = true;
                }
            }

            return isIntermediateU;
        }

        private bool IsLastU(int previusCharDirection, int thisCharDirection, int nextCharDirection)
        {
            bool isLastU = false;

            if (_listaUltimasU != null)
            {
                if (CadenaRevisar[previusCharDirection] == 'U' &&
                    CadenaRevisar[thisCharDirection] == 'U' &&
                    CadenaRevisar[nextCharDirection] != 'U')
                {

                    isLastU = true;
                }
            }

            return isLastU;
        }

        private bool IsLastUAndLetter(int previusCharDirection, int thisCharDirection)
        {
            bool isLastU = false;

            if (_listaUltimasU != null)
            {
                if (CadenaRevisar[previusCharDirection] == 'U' &&
                    CadenaRevisar[thisCharDirection] == 'U')
                {

                    isLastU = true;
                }
            }

            return isLastU;
        }

        private void RecorrerListas()
        {
            if (_listaPrimerasU.Count == _listaUltimasU.Count)
            {
                for (int i = 0; i < _listaPrimerasU.Count; i++)
                {
                    if (_listaUltimasU[i] - _listaPrimerasU[i] == _listaNumeroIntermedioEntreU[i])
                    {
                        CoordenadasU coordenadaU = new CoordenadasU(_listaPrimerasU[i], _listaUltimasU[i]);
                        _listaCoordenadas.Add(coordenadaU);
                    }
                }
            }
        }
    }
}
