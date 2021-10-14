using System;
using System.Collections.Generic;
using System.Text;

namespace Day9_GestioneCC
{
   public static class Menu
    {

        public static void Start()
        {

            AppManager.AggiungiDatiProva();
            Console.WriteLine("***Benvenuto nell'app di gestione del tuo conto.****\n");

            bool continua=true;

            do
            {

                Console.WriteLine("\n**************MENU******************\n");
                Console.WriteLine("Premi 1 per creare un conto");
                Console.WriteLine("Premi 2 per eliminare un conto");
                Console.WriteLine("Premi 3 per visualizzare i tuoi conti");
                Console.WriteLine("Premi 0 uscire dall'app");

                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta tra le possibili opzioni");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 3));

                switch (scelta)
                {
                    case 1:

                        AppManager.AggiungiConto();

                        break;


                    case 2:

                        AppManager.EliminaConto();

                        break;

                    case 3:

                        AppManager.StampaConti();
                        break;

                    case 0:
                        Console.WriteLine("Arrivederci!");
                        continua = false;
                        break;

                }

            } while (continua == true);






        }

    }
}
