using System;
using System.Collections.Generic;
using System.Text;

namespace Day9_GestioneCC
{
   public static class AppManager
    {


        public static void AggiungiDatiProva()
        {
            ContoCorrente cc1 = new ContoCorrente
            {
                Intestatario = "Paola",
                TipoDiConto = (Tipo)1,
                Saldo = 234,
                NumeroConto= "01"
            };

            conti.Add(cc1);
        }
        public static List<ContoCorrente> conti = new List<ContoCorrente>();


        public static void AggiungiConto()
        {
            ContoCorrente conto = new ContoCorrente();

            Console.WriteLine("\nInserisci il nome dell'intestatario:\n");
            conto.Intestatario = Console.ReadLine();
            
            conto.TipoDiConto = InserisciTpoDiConto();

            conto.Saldo = InserisciSaldo();

            Console.WriteLine("\nInserisci il numero del conto:\n");
            conto.NumeroConto = Console.ReadLine();

            conti.Add(conto);

        }

        public static Tipo InserisciTpoDiConto()
        {

            Console.WriteLine("\nInserisci il tipo di conto. Premi:\n"+
                $"{(int)Tipo.Corrente} per {Tipo.Corrente}\n" +
                $"{(int)Tipo.Risparmio} per {Tipo.Risparmio}\n");
            int tipo;
            do
            {
                Console.WriteLine("Fai la tua scelta");
            } while (!(int.TryParse(Console.ReadLine(), out tipo) && tipo >= 1 && tipo <= 2));

            return (Tipo)tipo;
        }

        public static double InserisciSaldo()
        {
            double saldo;

            do
            {
                Console.WriteLine("Inserisci il saldo sul tuo conto.");
            } while (!(double.TryParse(Console.ReadLine(), out saldo) && saldo > 0));

            return saldo;
        }

        public static void EliminaConto()
        {

            Console.WriteLine("I conti presenti nella tua app sono:");
            StampaConti();
            Console.WriteLine("Scrivi il numero del conto che vuoi eliminare");
            string numeroDaRicercare = Console.ReadLine();
            ContoCorrente contoTrovato = CercaConto(numeroDaRicercare);
            if (contoTrovato == null)
            {
                Console.WriteLine("Conto non trovato. Numero del conto errato!");
            }
            else
            {
                conti.Remove(contoTrovato);
                Console.WriteLine("Conto eliminato correttamente!");
            }


        }


        public static ContoCorrente CercaConto(string numeroConto)
        {
            foreach (var item in conti)
            {
                if (item.NumeroConto == numeroConto)
                {
                    return item;
                }
            }
            return null;
        }

        public static void StampaContiDaLista(List<ContoCorrente> listaConti)
        {
            if (listaConti.Count == 0)
            {
                Console.WriteLine("Non sono presenti conti.");
            }
            else
            {
                Console.WriteLine("Numero di conto \n");
                foreach (var item in listaConti)
                {
                    Console.WriteLine($"{item.NumeroConto}");
                }
            }
        }


        public static void StampaConti()
        {
            StampaContiDaLista(conti);
        }


    }
}
