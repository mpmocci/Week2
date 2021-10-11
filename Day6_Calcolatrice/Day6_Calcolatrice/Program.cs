using System;

namespace Day6_Calcolatrice
{
    class Program
    {
        static void Main(string[] args)
        {


            /**Calcolatrice***/
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ******** Welcome to the Calculator!*******\n");
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(" Inserisci il tuo username:\n");
            Console.ForegroundColor = ConsoleColor.White;
            string userName = Console.ReadLine();

            int firstNumber;
            int secondNumber;
            bool replay= false;


            do
            {

                do { 
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nInserisci il primo numero intero: \n");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                while (!int.TryParse(Console.ReadLine(), out firstNumber));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"------Il primo numero che hai inserito è {firstNumber}------\n");

                do
                {
                    Console.WriteLine("Inserisci il secondo numero intero: \n");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                while (!int.TryParse(Console.ReadLine(), out secondNumber));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"-----Il secondo numero che hai inserito è {secondNumber}------\n");

                char choice;
                int result;
                double divisionResult;

                do { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" \n **************Menù******************** \n" +
                    "Scegli: \n" +
                    "A per fare la somma dei due numeri \n" +
                    "B per fare la differenza dei due numeri \n" +
                    "C per fare la moltiplicazione dei due numeri \n" +
                    "D per fare la divisione dei due numeri \n");
                    Console.ForegroundColor = ConsoleColor.White;

                    choice = Console.ReadKey().KeyChar;


                }
                while (!(choice.ToString().ToUpper() == "A" || choice.ToString().ToUpper() == "B" ||
                choice.ToString().ToUpper() == "C" || choice.ToString().ToUpper() == "D"));

                switch (choice.ToString().ToUpper())
                {

                    case "A":

                        Adding(firstNumber, secondNumber, out result);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\n Il  risultato è {result}");
                        break;

                    case "B":

                        Subtracting(firstNumber, secondNumber, out result);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\n Il  risultato è {result}");

                        break;

                    case "C":

                        Multiplying(firstNumber, secondNumber, out result);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"\n Il risultato è {result}");

                        break;

                    case "D":

                        if (secondNumber == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Impossibile dividere per zero.\n");
                            
                        }

                        else
                        {
                             Dividing(firstNumber, secondNumber, out divisionResult);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"\n Il risultato è {divisionResult}");

                        }
                        break;


                }


                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(" \n Vuoi rigiocare? Digita sì per continuare, qualsiasi altra cosa per uscire. \n");
                string userAnswer = Console.ReadLine();

                if (userAnswer.ToLower() == "sì")
                {
                    replay = true;
                }
                else
                {
                    replay = false;
                }


            }
            while ( replay == true);
        }

        //*********METODI***********


        private static int Adding(int a, int b, out int result)
        {

            result = a + b;


            return result;

        }

        private static int Subtracting(int a, int b, out int result)
        {



            if (a > b)
            {
                result = a - b;
            }
            else
            {
                result = b - a;
            }

            return result; 


        }

        private static int Multiplying(int a, int b, out int result)
        {

            result = a * b;

            return result;
        }

        private static double Dividing(int a, int b, out double result)
        {

   
             result = (double)a / b;
            

            return result;

        }
    }
}
