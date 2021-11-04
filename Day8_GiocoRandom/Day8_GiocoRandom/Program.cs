using System;
using System.IO;


namespace Day8_GiocoRandom
{
    class Program
    {
        static void Main(string[] args)
        {


            int choice;
            bool replay;
            int random;
            int userInput;
            int attempt = 0;

            do
            {

                ShowMenu();

                CheckUserChoice(choice);

                if (choice == 1)
                {

                    GenerateRandom(random);
                    CheckUserInput(userInput, ref attempt);

                    if (userInput == 0)
                    {
                        Console.WriteLine("****Partita interrotta!***" +
                        $"Il numero estratto è {random}.");
                        break;
                    }
                    else
                    {

                        if (userInput == random)
                        {

                            Console.WriteLine("****CONGRATULAZIONI!HAI VINTO!***");

                        }
                        else
                        {

                            do
                            {
                                GivingHint(ref random, ref userInput);
                                CheckUserInput(userInput, ref attempt);
                                if (userInput == 0)
                                {
                                    Console.WriteLine("****Partita interrotta!***" +
                                    $"Il numero estratto è {random}.");
                                    break;
                                }

                            }
                            while (userInput == random);

                            Console.WriteLine("****CONGRATULAZIONI!HAI VINTO!***");


                        }

                    }


                }
                else
                {
                    Console.WriteLine("\nArrivederci!\n");
                }




                Console.WriteLine("\n Vuoi rigiocare? Premi:\n " +
                "1) per rigiocare" +
                "2) per uscire");

                CheckUserChoice(choice);

                if (choice == 1)
                {
                    replay == true;
                }


            }
            while (replay == true);



        }

        /********FUNZIONI*********/

        //Suggerimento

        private static void GivingHint(ref int random, ref int userInput)
        {

            if (userInput < random)
            {
                Console.WriteLine("Tenta con un numero più alto!");
            }
            else
            {
                Console.WriteLine("Tenta con un numero più basso!");
            }

        }

        //Input utente + controllo numero in un certo range

        private static int CheckUserInput(int userInput, int ref attempt)
        {

            Console.WriteLine($"\nFino ad ora hai fatto {attempt} tentativi.\n" +
            "Prova ad indovinare il numero estratto. Inserisci un numero tra 1 e 100.\n" +
            "Premi 0 per interrompere la partita.\n");
            bool correctChoice = int.TryParse(Console.ReadLine(), out userInput); //controllo per verificare che è stata scelta una delle opzioni


            while (correctChoice == false || userInput < 0 || userInput > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Inserire un numero compreso tra 1 e 100.");
                Console.ForegroundColor = ConsoleColor.White;
                correctChoice = int.TryParse(Console.ReadLine(), out userInput);

            }
            attempt++;
            return userInput;
        }

        //Generare numero random
        private static int GenerateRandom(int random)
        {

            random = new Random().Next(1, 101);

            string path = @"...\NumeroDaIndovinare.txt";

            using (StreamWriter sw1 = new StreamWriter(path, true))
            {
                sw1.WriteLine($"Il numero segreto è {random}");
            }


            return random;
        }

        //Controllo inserimento di un numero
        private static int CheckUserChoice(int choice)
        {

            bool correctChoice = int.TryParse(Console.ReadLine(), out choice); //controllo per verificare che è stata scelta una delle opzioni

            while (correctChoice == false || !(choice == 1 || choice == 2))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Inserire una scelta tra quelle mostrate.");
                Console.ForegroundColor = ConsoleColor.White;
                correctChoice = int.TryParse(Console.ReadLine(), out choice);

            }

            return choice;

        }

        //Menù
        private static void ShowMenu()
        {

            Console.WriteLine("********BENVENUTA!***********\n" +
"Inserisci il tuo nome:\n");

            string name = Console.ReadLine();

            Console.WriteLine($"Ciao {name}!\n\n" +
            "*********MENU***********\n" +
            "Premi:\n" +
            "1) per iniziare il gioco" +
            "2) per uscire dal gioco");


        }

    }
}