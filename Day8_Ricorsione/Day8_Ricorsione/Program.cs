using System;

namespace Day8_Ricorsione
{
    class Program
    {
        static void Main(string[] args)
        {
            // int n = 6;

            //FIBONACCI con array

            //int[] fibonacci = new int[n];

            //for (int i = 0; i < n; i++)
            //{
            //    if (n <= 1)
            //    {
            //        fibonacci[i] = 1;
            //    }
            //    else {
            //        fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            //    }
            //}


            /****FATTORIALE iterativo***/

            //int fattoriale=1;

            //for(int i=1; i<=n; i++)
            //{
            //    fattoriale *=i;
            //}

            /****FATTORIALE ricorsivo***/

            //    CalcoloFattoriale(n);


            //    Console.WriteLine($"Il fattoriale di {n} è {CalcoloFattoriale(n)}");


            /************CALCOLO INTERESSE**********/

            double soldi=10000;
            double anni=3;
            double interesse=0.03;

            CalcoloInteresse(soldi, anni, interesse);
            Console.WriteLine($"{CalcoloInteresse(soldi, anni, interesse)}");

        }

        /*******CALCOLO INTERESSE****/

        private static double CalcoloInteresse(double soldi, double anni, double interesse){

            if (anni == 0)
            {
                                
              return soldi;
            }
            else
            {
                
                return CalcoloInteresse((soldi + (interesse*soldi)), anni-1, interesse);
            }

        }


        /****FATTORIALE CON RICORSIONE*****/

        private static int CalcoloFattoriale(int n)
        {

            if (n == 1 || n==0)
            {
                return 1;
            }
            else
            {
                return CalcoloFattoriale(n - 1) * n;
            }

        }

        /******FIBONACCI con RICORSIONE***/

        private static int Fibonacci(int n)
        {
            if(n==1 || n == 2)
            {
                return 1;

            }


            else {
                return Fibonacci(n - 1) + Fibonacci(n - 2);

            }

        }
    }
}
