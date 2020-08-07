using System;
using System.Collections.Generic;
using System.Text;

namespace MU.Modelos
{
    class AdministradorReglas
    {
        private List<CoordenadasIII> _listaCoordenadas;

        public AdministradorReglas()
        {
            _listaCoordenadas = new List<CoordenadasIII>();
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

            var muRevisado = ContieneTresI(mu);

            if (muRevisado.ContieneIII)
            {
                List<Mu> listaReglaTres = RetornarListaMuConUSustituido(muRevisado, regla);
                _listaCoordenadas.Clear();
                return listaReglaTres;
            }
            else
            {
                return null;
            }
        }

        /*public Mu AplicarReglaCuatroSiEsPosible(Mu mu)
        {
            if ()
            {
                return mu
            }
            else
            {
                return null;
            }
        }
        */

        private Mu ContieneTresI(Mu mu)
        {
            for (int i = 1; i < mu.Cadena.Length; i++)
            {
                if (mu.Cadena.Length > i + 2  &&
                 (mu.Cadena[i].ToString() + mu.Cadena[i + 1].ToString() + mu.Cadena[i + 2].ToString()).Equals("III"))
                {
                    mu.ContieneIII = true;
                    CoordenadasIII coordenadas = new CoordenadasIII(i, i + 1, i + 2);
                    _listaCoordenadas.Add(coordenadas);
                }
            }

            return mu;
        }

        private Mu CopiarObjetoCadena(Mu mu, string regla)
        {
            Mu newMu = new Mu(mu.Cadena, regla);
            return newMu;
        }

        private List<Mu> RetornarListaMuConUSustituido(Mu mu, string regla)
        {
            List<Mu> listMuSustituido = new List<Mu>();

            foreach(var coordenada in _listaCoordenadas)
            {
                if (coordenada.YaUtilizada == false) 
                {
                    Mu newMu = new Mu(NuevaCadena(coordenada, mu), regla);
                    listMuSustituido.Add(newMu);
                }
            }

            return listMuSustituido;
        }

        private string NuevaCadena(CoordenadasIII coordenada, Mu muRevisado)
        {
            string cadena = "M";

            for(int i = 1; i < muRevisado.Cadena.Length; i++)
            {
                if(i == coordenada.CoordenadaI)
                {
                    cadena += "U";
                } else if((i == coordenada.CoordenadaII) || (i == coordenada.CoordenadaIII))
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
    }
}