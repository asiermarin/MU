using MU.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Timers;

namespace MU
{
    class AplicarTeorema
    {
        private List<Mu> _listaDeCadenas;

        private Mu _mu;

        private AdministradorReglas _adminReglas;

        public AplicarTeorema()
        {
            _listaDeCadenas = new List<Mu>();
            _mu = new Mu("", "0");
            _adminReglas = new AdministradorReglas();

            IniciarBuble();
        }

        private void IniciarBuble()
        {
            var mi = CrearCadenaInicial();
            _listaDeCadenas.Add(mi);

            int intentos = 0;
            do
            {
                intentos++;

                var listaIntento = ClonarLista();
                _listaDeCadenas.Clear(); 
                AplicarReglas(listaIntento);
                listaIntento.Clear();

                EncontrarMu();
                ExportarResultados(intentos);

            } while (_mu.EsMu == false);
        }

        private void EncontrarMu()
        {
            if (_listaDeCadenas.Find(mu => mu.EsMu == true) == null)
            {
                _mu.EsMu = false;
            }
            else
            {
                _mu = _listaDeCadenas.Find(mu => mu.EsMu == true);
            }
        }

        private Mu CrearCadenaInicial()
        {
            Mu muInicial = new Mu("MI", "0");
            return muInicial;
        }

        private List<Mu> ClonarLista()
        {
            List<Mu> listaIntento = new List<Mu>();

            foreach(var mu in _listaDeCadenas)
            {
                listaIntento.Add(mu);
            }

            return listaIntento;
        }

        private void AplicarReglas(List<Mu> listaIntento)
        {
            foreach (var muDeLista in listaIntento)
            {
                var muReglaUno = _adminReglas.AplicarReglaUnoSiEsPosible(muDeLista);   
                var muReglaDos = _adminReglas.AplicarReglaDosSiEsPosible(muDeLista);
                var listReglaTres = _adminReglas.AplicarReglaTresSiEsPosible(muDeLista);
                var listReglaCuatro = _adminReglas.AplicarReglaCuatroSiEsPosible(muDeLista);
                
                GuardarInstancia(muReglaUno);
                GuardarInstancia(muReglaDos);
                GuardarVariasInstacias(listReglaTres);
                GuardarVariasInstacias(listReglaCuatro);
            }
        }

        private void ExportarResultados(int intentos)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Intento " + intentos);

            foreach (var muDeLista in _listaDeCadenas)
            {
                Console.WriteLine(muDeLista.Cadena + " ---------> "+ "(" + muDeLista.UltimaRegla + ") " + muDeLista.EsMu);
            }

            Console.WriteLine("----------------------------------");
        }

        private void GuardarInstancia(Mu mu)
        {
            if (mu != null && mu.Cadena.Length <= 20)
            {
                _listaDeCadenas.Add(mu);
            }
        }

        private void GuardarVariasInstacias(List<Mu> listReglaTres)
        {
            if (listReglaTres != null)
            {
                foreach (var muReglaTres in listReglaTres)
                {
                    GuardarInstancia(muReglaTres);
                }
            }
        }
    }
}
