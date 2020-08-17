using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MU.Modelos
{
    class Limpiador
    {
        public bool ListaLimpia { get; set; }

        public Limpiador()
        {
            ListaLimpia = false;
        }

        public void LimpiarDuplicados(List<Mu> listaMu)
        {
            listaMu.GroupBy(mu => mu.Cadena).Select(mu => mu.First());
            listaMu.Distinct().Select(mu => mu.Cadena);
        }

        public void LimpiarMenosPosibles(List<Mu> listaMu)
        {
            string muNoPosible1 = "MUIUI";
            string muNoPosible2 = "MIUIU";

            foreach (var mu in listaMu)
            {
                if (mu.Cadena[1].ToString().Equals(muNoPosible1[1].ToString()) &&
                    mu.Cadena[2].ToString().Equals(muNoPosible1[2].ToString()) &&
                    mu.Cadena[3].ToString().Equals(muNoPosible1[3].ToString()) &&
                    mu.Cadena[4].ToString().Equals(muNoPosible1[4].ToString()))
                {
                    mu.Limpiar = true;
                } 
                else if (mu.Cadena[1].ToString().Equals(muNoPosible2[1].ToString()) &&
                    mu.Cadena[2].ToString().Equals(muNoPosible2[2].ToString()) &&
                    mu.Cadena[3].ToString().Equals(muNoPosible2[3].ToString()) &&
                    mu.Cadena[4].ToString().Equals(muNoPosible2[4].ToString()))
                {
                    mu.Limpiar = true;
                }
                else
                {
                    mu.Limpiar = false;
                }
            }
        }
    }
}
