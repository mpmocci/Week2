using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Paola_Mocci_TestWeek2
{
    public static class AppManager
    {
        public static List<Task> tasks = new List<Task>();


        public static void StampaTasksDaLista(List<Task> listaTasks)
        {
            if (listaTasks.Count == 0)
            {
                Console.WriteLine("\nNon sono presenti tasks.\n");
            }
            else
            {
                Console.WriteLine("\nDescrizione \t\t\t\t\t\t Data di scadenza \t\t  Priorità\n");
                foreach (var item in listaTasks)
                {
                    Console.WriteLine($"{item.Descrizione} \t\t\t\t {item.DataScadenza.ToShortDateString()} \t\t\t {item.LivelloPriorità}");
                }
            }
        }

        public static void StampaTasks()
        {
            StampaTasksDaLista(tasks);
        }

        public static void AggiungiTaskSuLista(List<Task> listaTasks)
        {
            Task task = new Task();

            bool continua = true;

            do
            {
                Console.WriteLine("\nInserisci la descrizione della task.\n");
                string descrizione = Console.ReadLine();

                Task taskTrovata = CercaTask(descrizione);
                if (taskTrovata != null)
                {
                    Console.WriteLine("\nE' gia presente una task con questo nome.\n");
                    continua = false;
                }
                else
                {
                    continua = true;
                    task.Descrizione = descrizione;

                }

            } while (continua == false);

            task.DataScadenza = InserisciDataScadenza();
            task.LivelloPriorità = InserisciLivelloPriorità();

            tasks.Add(task);
            Console.WriteLine("\nTask aggiunto correttamente.\n");


        }

        public static void AggiungiTask()
        {
            AggiungiTaskSuLista(tasks);
        }

        public static void SalvaSuFileDaLista(List<Task> tasks)
        {

            string path = @"C:\Users\paola\source\repos\Paola_Mocci_TestWeek2\TasksSalvate.txt";

            foreach (var item in tasks)
            {

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine($"{item.Descrizione},{item.DataScadenza},{item.LivelloPriorità}");
                }
            }

        }

        public static void SalvaSuFile()
        {
            SalvaSuFileDaLista(tasks);
        }

        public static Priorità InserisciLivelloPriorità()
        {

            Console.WriteLine("\nInserisci il livello di priorità: \n");
            Console.WriteLine($"Premi {(int)Priorità.Bassa} per una priorità {Priorità.Bassa}");
            Console.WriteLine($"Premi {(int)Priorità.Media} per una priorità {Priorità.Media}");
            Console.WriteLine($"Premi {(int)Priorità.Alta} per una priorità {Priorità.Alta}");

            int priorità;
            do
            {
                Console.WriteLine("\nFai la tua scelta.\n");
            } while (!(int.TryParse(Console.ReadLine(), out priorità) && priorità >= 1 && priorità <= 3));
            return (Priorità)priorità;

        }

        public static DateTime InserisciDataScadenza()
        {

            bool conversione;
            DateTime date;
            DateTime dataInserimento = DateTime.Today;

            do
            {
                Console.WriteLine("\nInserisci la data di scadenza della task (MM DD YYYY).\n");
                conversione = DateTime.TryParse(Console.ReadLine(), out date);
                if (date <= dataInserimento)
                {
                    Console.WriteLine("\n La data di scadenza deve essere posteriore alla data di inserimento della task.\n");
                }
            } while (!(conversione == true && date > dataInserimento));
            return date;
        }

        public static void EliminaTask()
        {
            Console.WriteLine("\nLe tasks presenti nella tua agenda sono:\n");
            StampaTasks();
            Console.WriteLine("\nScrivi la descrizione della task che vuoi eliminare:\n");
            string descrizioneDaRicercare = Console.ReadLine();

            Task taskTrovata = CercaTask(descrizioneDaRicercare);
            if (taskTrovata == null)
            {
                Console.WriteLine("\nTask non trovata. Descrizione errata!\n");
            }
            else
            {
                tasks.Remove(taskTrovata);
                Console.WriteLine("\nTask eliminata correttamente!\n");
            }
        }

        public static Task CercaTask(string descrizione)
        {
            foreach (var item in tasks)
            {
                if (item.Descrizione == descrizione)
                {
                    return item;
                }
            }
            return null;
        }

        public static void FiltraTasksPerImportanza()
        {
            Priorità priorità = InserisciLivelloPriorità();
            List<Task> tasksFiltrate = new List<Task>();

            foreach (var item in tasks)
            {
                if (item.LivelloPriorità == priorità)
                {

                    tasksFiltrate.Add(item);

                }
            }

            StampaTasksDaLista(tasksFiltrate);
        }


        //TODO: Da vedere lettura da file
        //formattare bene il file di input senza spazi tra le virgole
        public static void AggiungiTasksDiProva(List<Task> listaTasks)
        {
            string path = @"C:\Users\paola\source\repos\Paola_Mocci_TestWeek2\TasksSalvate.txt";


            StreamReader file = new StreamReader(path);

            
            string line;
            while ((line=file.ReadLine()) != null) { 

                Task task = new Task();
                var proprietà = line.Split(",");
                task.Descrizione = proprietà[0];
                task.DataScadenza = DateTime.Parse(proprietà[1]);
                task.LivelloPriorità = (Priorità)Enum.Parse(typeof(Priorità), proprietà[2]);
                listaTasks.Add(task);
            }

            file.Close();



        }

        public static void AggiungiTasksProva()
        {
            AggiungiTasksDiProva(tasks);
        }




        //public static void AggiungiTasksProva()
        //{
        //    Task task1 = new Task()
        //    {
        //        Descrizione = "Aperitivo con Andre da Maiori",
        //        LivelloPriorità = (Priorità)2,
        //        DataScadenza = new DateTime(2021, 10, 16)

        //    };
        //    tasks.Add(task1);


        //    Task task2 = new Task()
        //    {
        //        Descrizione = "Consegnare esercitazione",
        //        LivelloPriorità = (Priorità)3,
        //        DataScadenza = new DateTime(2021, 10, 15)

        //    };
        //    tasks.Add(task2);



        //    Task task3 = new Task()
        //    {
        //        Descrizione = "Finire il codice Pippo.cs ",
        //        LivelloPriorità = (Priorità)1,
        //        DataScadenza = new DateTime(2021, 10, 19)

        //    };
        //    tasks.Add(task3);

        //    Task task4 = new Task()
        //    {
        //        Descrizione = "Preparare meeting PowerPoint",
        //        LivelloPriorità = (Priorità)3,
        //        DataScadenza = new DateTime(2021, 12, 19)

        //    };
        //    tasks.Add(task4);





        //}



    }
}
