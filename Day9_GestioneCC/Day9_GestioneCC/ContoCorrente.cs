using System;
using System.Collections.Generic;
using System.Text;

namespace Day9_GestioneCC
{
  public class ContoCorrente
    {

        public string Intestatario { get; set; }
        public Tipo TipoDiConto { get; set; }
        public double Saldo{ get; set; }
        public string NumeroConto{ get; set; }


        public ContoCorrente()
        {


        }

    }

    public enum Tipo
    {
        Corrente=1,
        Risparmio=2 

    }
}
