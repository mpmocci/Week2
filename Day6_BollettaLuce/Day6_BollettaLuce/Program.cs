using System;

namespace Day6_BollettaLuce
{
    class Program
    {
        static void Main(string[] args)
        {
            /***** Realizzare un’applicazione console che consenta di eseguire il calcolo della bolletta della luce.
             Si richiede di sviluppare un menù attraverso cui l’utente può scegliere di:
            * inserire i propri dati(nome, cognome e kwH consumati);
            * richiedere il calcolo del costo della bolletta che è costituito da una quota fissa di 40€ più il prodotto tra i kwH e 10.
            * stampare a video i valori della bolletta, inclusi nome, cognome e costo pagato.
            Ciascuna delle operazioni descritte sopra dovrà essere implementata attraverso una opportuna routine. ******/

            bool restart; //variabile per tornare al menù principale
            bool conversion;

            //variabili dati personali
            string name = null;
            string surname = null;
            double kwh = -1;
            double cost = 0;

            do //Ciclo per chiedere se alla fine si vuole continuare o no
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("********Benvenuto nell'App Bolletta della Luce********* \n \n" +
                    "Digitare il numero corrispondente a una delle seguenti azioni:\n" +
                    "1) Inserire i dati personali\n" +
                    "2) Calcolare il costo della bolletta\n" +
                    "3) Visualizzare i dati relativi all'ultima bolletta \n \n");
                Console.ForegroundColor = ConsoleColor.White;

                //CONTROLLO che l'utente abbia effettuato una delle scelte del menù
                int choice;
                bool correctChoice = int.TryParse(Console.ReadLine(), out choice); //controllo per verificare che è stata scelta una delle opzioni

                while (correctChoice == false || !(choice == 1 || choice == 2 || choice == 3))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inserire una scelta tra quelle mostrate.");
                    Console.ForegroundColor = ConsoleColor.White;
                    correctChoice = int.TryParse(Console.ReadLine(), out choice);

                }




                switch (choice)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.White;
                        TypePersonalData(out name, out surname, out kwh);

                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.White;
                        //se i kwh non erano stati inseriti, vengono richiesti
                        if (kwh == -1)
                        {
   
                            CheckConversionKwh(out conversion, ref kwh);

                        }

                        CalculateBill(ref kwh, out cost);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"\n Il costo della bolletta è di {cost} euro. \n");

                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.White;

                        //se i dati personali sono mancanti, viene chiesto di reinserirli
                        if (name == null)
                        {
                            Console.WriteLine("\nNome assente. Inserire il proprio nome.\n");
                            name = Console.ReadLine();
                        }


                        if (surname == null)
                        {
                            Console.WriteLine("\nCognome assente. Inserire il proprio nome.\n");
                            surname = Console.ReadLine();
                        }


                        if (kwh == -1)
                        {

                            CheckConversionKwh(out conversion, ref kwh);
                            CalculateBill(ref kwh, out cost);
                        }

                        DisplayBill(ref name, ref surname, ref cost);

                        break;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Vuoi tornare al Menù principale? Digita 'sì' per continuare, altrimenti qualsiasi altro testo per uscire.");
                string choiceRestart = Console.ReadLine().ToString().ToLower();

                if (choiceRestart == "sì")
                {
                    restart = true;
                }
                else
                {
                    restart = false;
                }

            }

            while (restart == true);


        }


        /**********METODI********/


        
        private static double TypePersonalData(out string name, out string surname, out double kwh)
        {
            bool conversion; 

            Console.WriteLine("\n Inserire il proprio nome:");
            name = Console.ReadLine();

            Console.WriteLine("\n Inserire il proprio cognome:");
            surname = Console.ReadLine();

            Console.WriteLine("Inserire i kilowattora consumati:");
            conversion = double.TryParse(Console.ReadLine(), out kwh);
            if (conversion == false)
            {
                do
                {
                    Console.WriteLine("Inserire i kilowattora consumati:");
                    conversion = double.TryParse(Console.ReadLine(), out kwh);
                }
                while (conversion == false);
            }



            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" \n \nI dati inseriti sono i seguenti:\n \n" +
                $"Nome: {name}\n" +
                $"Cognome: {surname}\n" +
                $"kWh consumati: {kwh}\n");

            return kwh;

        }
        
        private static void CalculateBill(ref double kwh, out double cost)
        {

            cost = 40 + (kwh * 10);


        }
        
        private static void DisplayBill(ref string name, ref string surname, ref double cost)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n Dati relativi all'ultima bolletta: \n" +
               $"\nNOME: \t\t{name}\n" +
               $"COGNOME: \t{surname}\n" +
               $"COSTO: \t\t{cost}\n");
        }

        //metodo per controllare che l'utente abbia inserito un numero per i kwh e non una stringa
        private static void CheckConversionKwh(out bool conversion, ref double kwh)
        {
            Console.WriteLine("Inserire i kilowattora consumati:");
            conversion = double.TryParse(Console.ReadLine(), out kwh);
            if (conversion == false)
            {
                do
                {
                    Console.WriteLine("Inserire i kilowattora consumati:");
                    conversion = double.TryParse(Console.ReadLine(), out kwh);
                }
                while (conversion == false);
            }

        }



    }
}
