using System;
using System.Collections.Generic;
using System.Text;

namespace Paola_Mocci_TestWeek2
{
   public static class Menu
    {

        public static void Start()
        {

            AppManager.AggiungiTasksProva();

            Console.WriteLine("***Benvenuto nella tua agenda.****\n");

            bool continua = true;

            do
            {

                Console.WriteLine("\n**************MENU******************\n");
                Console.WriteLine("Premi 1 per visualizzare le tasks.");
                Console.WriteLine("Premi 2 per aggiungere una nuova task.");
                Console.WriteLine("Premi 3 per eliminare una task esistente.");
                Console.WriteLine("Premi 4 per filtrare le tasks per importanza.");
                Console.WriteLine("Premi 0 uscire dall'app e salvare le tue task su file di testo.");

                int scelta;
                do
                {
                    Console.WriteLine("\nFai la tua scelta tra le possibili opzioni.\n");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:

                        AppManager.StampaTasks();

                        break;


                    case 2:

                        AppManager.AggiungiTask();

                        break;

                    case 3:

                        AppManager.EliminaTask();
                        break;              
                            
                            
                    case 4:

                        AppManager.FiltraTasksPerImportanza();
                        break;

                    case 0:
                        Console.WriteLine("Arrivederci!");
                        continua = false;
                        AppManager.SalvaSuFile();
                        break;

                }

            } while (continua == true);



        }



    }
}
