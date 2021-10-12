using System;

namespace esercizio
{
    class Program
    {
        static void Main(string[] args)
        {
            //*************Creare un programma quiz con N domande facili e difficili. Se l'utente risponde
            //correttamente a una domanda facile, il suo punteggio aumenta di 2 punti, se risponde a una domanda
            //difficile  4 punti. se sbaglia perde 1 punto. Stampare il punteggio complessivo. 

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("***************Benvenuto al Quiz!************** \n \n");

            int questionNumber = 1;
            int punteggio = 0;

            do
            {
                askQuestion(ref questionNumber, ref punteggio);
                questionNumber++;
            }

            while (questionNumber <= 10);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n \n Il tuo punteggio complessivo è {punteggio}");




        }


        private static int askQuestion(ref int questionNumber, ref int punteggio)
        {
            string answer;
            int answerNum;

            switch (questionNumber)
            {

                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Qual'è la capitale dell'Italia?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answer = Console.ReadLine();
                    if (answer == "Roma")
                    {
                        punteggio += 2;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");
                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;


                case 2:
                    Console.WriteLine("Quanto fa 16 x 2?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answerNum = int.Parse(Console.ReadLine());
                    if (answerNum == 32)
                    {
                        punteggio += 2;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;


                case 3:
                    Console.WriteLine("Chi è il Presidente del Consiglio?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answer = Console.ReadLine();
                    if (answer == "Draghi")
                    {
                        punteggio += 2;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;


                case 4:
                    Console.WriteLine("Chi ha scritto la Divina Commedia?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answer = Console.ReadLine();
                    if (answer == "Dante")
                    {
                        punteggio += 2;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;

                case 5:
                    Console.WriteLine("Quanto fa 30:2?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answerNum = int.Parse(Console.ReadLine());
                    if (answerNum == 15)
                    {
                        punteggio += 2;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;

                case 6:
                    Console.WriteLine("Quanto vale log10?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answerNum = int.Parse(Console.ReadLine());
                    if (answerNum == 1)
                    {
                        punteggio += 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;


                case 7:
                    Console.WriteLine("Quante sono le forze fondamentali in Natura?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answerNum = int.Parse(Console.ReadLine());
                    if (answerNum == 4)
                    {
                        punteggio += 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;


                case 8:
                    Console.WriteLine("Qual'è l'interazione più debole tra le 4?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answer = Console.ReadLine();
                    if (answer == "Interazione gravitazionale" || answer == "Gravità" || answer == "gravità")
                    {
                        punteggio += 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;


                case 9:
                    Console.WriteLine("In che anno è scoppiata la seconda guerra mondiale?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answerNum = int.Parse(Console.ReadLine());
                    if (answerNum == 1939)
                    {
                        punteggio += 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! PUNTEGGIO:{punteggio} \n");

                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! PUNTEGGIO:{punteggio} \n");

                    }

                    break;


                case 10:
                    Console.WriteLine("Qual'è il quark più pesante?");
                    Console.ForegroundColor = ConsoleColor.White;
                    answer = Console.ReadLine();
                    if (answer == "Top" || answer == "top")
                    {
                        punteggio += 4;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta corretta! \n");


                    }
                    else
                    {
                        punteggio -= 1;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Risposta errata! \n");

                    }

                    break;
            }

            return punteggio;

        }
    }
}
