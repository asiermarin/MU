using MU.Test;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace MU.Modelos
{
    class AdministradorReglas
    {
        private List<CoordenadasIII> _listaCoordenadasIII;

        private List<CoordenadasU> _listaCoordenadasU;

        private Limpiador _limpiador;

        private CreadorCoordenadasU _creadorCoordenadas;

        public AdministradorReglas()
        {
            _listaCoordenadasIII = new List<CoordenadasIII>();
            _listaCoordenadasU = new List<CoordenadasU>();
            _creadorCoordenadas = new CreadorCoordenadasU();
            _limpiador = new Limpiador();
        }

        public Mu AplicarReglaUnoSiEsPosible(Mu mu) 
        {
            string regla = "1";
            Mu newMu = CopiarObjetoCadena(mu, regla);

            int tamaño = newMu.Cadena.Length;
            if (newMu.Cadena[tamaño - 1].Equals('I'))
            {
                string nuevaCadena = newMu.Cadena + "U";
                newMu.Cadena = nuevaCadena;

                return newMu;
                    
            } else
            {
                return null;
            }
        }
        
        public Mu AplicarReglaDosSiEsPosible(Mu mu)
        {
            string regla = "2";
            Mu newMu = CopiarObjetoCadena(mu, regla);

            if (newMu.Cadena[0].Equals('M'))
            {
                string x = "";

                for(int i = 1; i < newMu.Cadena.Length; i++)
                {
                    x += newMu.Cadena[i];
                }

                newMu.Cadena ="M"+ x + x;

                return newMu;
            }
            else
            {
                return null;
            }
        }
        
        public List<Mu> AplicarReglaTresSiEsPosible(Mu mu)
        {
            string regla = "3";

            var muRevisado = RevisarIII(mu);

            if (muRevisado.ContieneIII)
            {
                List<Mu> listaReglaTres = RetornarListaMuIII(muRevisado, regla);
                _listaCoordenadasIII.Clear();
                return listaReglaTres;
            }
            else
            {
                return null;
            }
        }


        public List<Mu> AplicarReglaCuatroSiEsPosible(Mu mu)
        {
            string regla = "4";

            var muRevisado = RevisarUU(mu);

            if (muRevisado.ContieneU)
            {
                List<Mu> listaReglaCuatro = RetornarListaMuU(muRevisado, regla);
                _listaCoordenadasU.Clear();
                return listaReglaCuatro;
            }
            else
            {
                return null;
            }
        }
        
        private Mu RevisarIII(Mu mu)
        {
            for (int i = 1; i < mu.Cadena.Length; i++)
            {
                if (mu.Cadena.Length > i + 2  &&
                 (mu.Cadena[i].ToString() + mu.Cadena[i + 1].ToString() + mu.Cadena[i + 2].ToString()).Equals("III"))
                {
                    mu.ContieneIII = true;
                    CoordenadasIII coordenadas = new CoordenadasIII(i, i + 1, i + 2);
                    _listaCoordenadasIII.Add(coordenadas);
                }
            }

            return mu;
        }

        private Mu RevisarUU(Mu mu)
        {
            _creadorCoordenadas.CadenaRevisar = mu.Cadena;

            /*
            for (int i = 1; i < mu.Cadena.Length; i++)
            {
                if (mu.Cadena.Length > i + 1 &&
                    (mu.Cadena[i].ToString() + mu.Cadena[i + 1].ToString()).Equals("UU"))
                {
                    mu.ContieneU = true;
                    CoordenadasU coordenadas = CrearCoordenadas(mu, i);
                    _listaCoordenadasU.Add(coordenadas);
                }
            }
            */
            foreach (CoordenadasU coordenada in _creadorCoordenadas.DevolverListaCoordenadas())
            {
                _listaCoordenadasU.Add(coordenada);
            }

            if (_listaCoordenadasU.Count > 0)
            {
                mu.ContieneU = true;
            }

            _creadorCoordenadas.LimpiarEnMemoria();

            return mu;
        }

        private CoordenadasU CrearCoordenadas(Mu mu, int primeraCoordenada)
        {
            int ultimaCoordenada = 0;

            for (int i = primeraCoordenada + 1; i < mu.Cadena.Length; i++)
            {
                // Sé que i es U, pero no que i + 2 es U
                if (mu.Cadena.Length > i + 1)
                {
                    if (mu.Cadena[i + 1].ToString().Equals("U"))
                    {
                        // Nothing
                    }
                    else
                    {
                        ultimaCoordenada = i;
                    }
                }
                else if (!(mu.Cadena.Length > i + 1))
                {
                    ultimaCoordenada = i;
                } 
            }

            CoordenadasU coordenadas = new CoordenadasU(primeraCoordenada, ultimaCoordenada);
            return coordenadas;
        }

        private Mu CopiarObjetoCadena(Mu mu, string regla)
        {
            Mu newMu = new Mu(mu.Cadena, regla, mu.Historial);
            return newMu;
        }

        private List<Mu> RetornarListaMuIII(Mu mu, string regla)
        {
            List<Mu> listMuSustituido = new List<Mu>();

            foreach(var coordenada in _listaCoordenadasIII)
            {
                if (coordenada.YaUtilizada == false) 
                {
                    Mu newMu = new Mu(NuevaCadenaReglaTres(coordenada, mu), regla, mu.Historial);
                    listMuSustituido.Add(newMu);
                }
            }

            return listMuSustituido;
        }

        private List<Mu> RetornarListaMuU(Mu mu, string regla)
        {
            List<Mu> listMuSustituido = new List<Mu>();

            foreach (var coordenada in _listaCoordenadasU)
            {
                if (coordenada.YaUtilizada == false)
                {
                    Mu newMu = new Mu(NuevaCadenaReglaCuatro(coordenada, mu), regla, mu.Historial);
                    listMuSustituido.Add(newMu);
                }
            }

            return listMuSustituido;
        }

        private string NuevaCadenaReglaTres(CoordenadasIII coordenada, Mu muRevisado)
        {
            string cadena = "M";

            for (int i = 1; i < muRevisado.Cadena.Length; i++)
            {
                if (i == coordenada.CoordenadaI)
                {
                    cadena += "U";
                } else if ((i == coordenada.CoordenadaII) || (i == coordenada.CoordenadaIII))
                {
                    // nothing
                }else
                {
                    cadena += muRevisado.Cadena[i].ToString();
                }
            }

            coordenada.YaUtilizada = true;
            return cadena;
        }

        private string NuevaCadenaReglaCuatro(CoordenadasU coordenada, Mu muRevisado)
        {
            string cadena = "M";

            for (int i = 1; i < muRevisado.Cadena.Length; i++)
            {
                if (i == coordenada.CoordenadaPrimera)
                {
                    cadena += "U";
                }
                else if (i >= coordenada.CoordenadaPrimera && i <= coordenada.CoordenadaUltima)
                {
                    // Nothing
                }
                else
                {
                    cadena += muRevisado.Cadena[i].ToString();
                }
            }

            coordenada.YaUtilizada = true;
            return cadena;
        }
    }
}