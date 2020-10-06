using MU.Modelos;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MU
{
    class AplicarTeorema
    {
        private const int TIME_INTERVAL_IN_MILLISECONDS = 4000;

        private List<Mu> _listaDeCadenas;

        private Mu _mu;

        private AdministradorReglas _adminReglas;

        private Limpiador _limpiador;

        public AplicarTeorema()
        {
            _listaDeCadenas = new List<Mu>();
            _mu = new Mu("", "0", new List<string>());
            _adminReglas = new AdministradorReglas();
            _limpiador = new Limpiador();
        }

        public void IniciarBucle()
        {
            var mi = CrearCadenaInicial();
            _listaDeCadenas.Add(mi);

            List<Mu> listaIntento = new List<Mu>();

            int intentos = 0;
            do
            {
                intentos++;
                listaIntento.AddRange(_listaDeCadenas);
                _listaDeCadenas.Clear();

                AplicarReglasYGuardar(listaIntento);
                listaIntento.Clear();
                    
                EncontrarMu();
                Limpiar();
                ExportarResultados(intentos);
                Thread.Sleep(TIME_INTERVAL_IN_MILLISECONDS);

            } while (_mu.EsMu == false);
        }

        private void Limpiar()
        {
            _limpiador.LimpiarDuplicados(_listaDeCadenas);
            _limpiador.LimpiarMenosPosibles(_listaDeCadenas);

            _listaDeCadenas = _limpiador.LimpiarListaCadenas(_listaDeCadenas);
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
            Mu muInicial = new Mu("MI", "", new List<string>());
            return muInicial;
        }

        private void AplicarReglasYGuardar(List<Mu> listaIntento)
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
            Console.WriteLine("Intento " + intentos + " y elimindos: " + _limpiador.ObjetosEliminados);

            foreach (var muDeLista in _listaDeCadenas)
            {
                Console.WriteLine(muDeLista.Cadena + " ---------> " + "(" + muDeLista.UltimaRegla + ") " + muDeLista.EsMu);
                
                string historial = "";
                foreach(var regla in muDeLista.Historial)
                {
                    historial += regla;
                }

                Console.WriteLine(historial);
            }

            Console.WriteLine("Elimindos: " + _limpiador.ObjetosEliminados);
            Console.WriteLine("----------------------------------");
        }

        private void GuardarInstancia(Mu mu)
        {
            if (mu != null && mu.Cadena.Length <= 30)
            {
                _listaDeCadenas.Add(mu);
            }
        }

        private void GuardarVariasInstacias(List<Mu> listReglaTres)
        {
            if (listReglaTres != null)
            {
                _listaDeCadenas.AddRange(listReglaTres);
            }
        }
    }
}