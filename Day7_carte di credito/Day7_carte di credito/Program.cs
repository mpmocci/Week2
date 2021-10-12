using System;

namespace Day7_carte_di_credito
{
    class Program
    {
        static void Main(string[] args)
        {

            // Le carte di pagamento sono lunghe 16 cifre.
            // Le prime 6 cifre rappresentano un numero di identificazione univoco per la banca che ha emesso la carta.
            // Le successive 2 cifre determinano il tipo di carta (ad es. debito, credito, regalo).
            // Le cifre da 9 a 15 sono il numero di serie della carta
            // L'ultima cifra è utilizzata come cifra di controllo per verificare se il numero della carta è valido.

            // Hans Peter ha inventato un metodo per determinare se un numero di carta di credito è sintatticamente valido
            // Step 1 : Vengono raddoppiate le cifre che si trovano in posizione dispari e
            // Step 2 : Se questo "raddoppio" risulta in un numero a due cifre, viene sottratto 9 da esso per ottenere una sola cifra.
            // Step 3 : Vengono sommante tutte le cifre ottenute
            // Step 4 : Vengono aggiunte le cifre nelle posizioni pari
            // Step 5 : Se il risultato è divisibile per 10, il numero della carta è valido; in caso contrario, non è valido.
            // Esempi
            // Carta di pagamento : 4 5 5 6 7 3 7 5 8 6 8 9 9 8 5 5
            // Step 1 : 8 5 10 6 14 3 14 5 16 6 16 9 18 8 10 5
            // Step 2 : 8 5 1 6 5 3 5 5 7 6 7 9 9 8 1 5
            // Step 3 : 8 + 1 + 5 + 5 + 7 + 7 + 9 + 1 = 43
            // Step 4 : 43 + (5+6+3+5+6+9+8+5) = 43 + 47 = 90
            // Step 5 : 90/10 = 9 resto 0 -> Numero della carta valido

            int[] cardNumber = new int[16];
            int[] oddNumbers = new int[8];
            int[] evenNumbers = new int[8];
            int[] doubledNumbers = new int[8];
            int result=0;


            TypeCreditCardNumber(cardNumber);
            CreateOddNumbersArray(cardNumber, oddNumbers);
            CreateEvenNumbersArray(cardNumber, evenNumbers);
            DoublingOddNumbers(oddNumbers, doubledNumbers);
            AddingOddNumbers(doubledNumbers, ref result);
            AddingNumbers(evenNumbers, ref result);
            CheckResult(ref result);



        }
        /***********FUNZIONI*********/

        //Crea array con il numero di carta di credito
        private static int[] TypeCreditCardNumber(int[] cardNumber)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*********BENVENUTO**********\n \n" );
            Console.ForegroundColor = ConsoleColor.White;

            for (int i=0; i<16; i++)
            {
                Console.WriteLine($"Inserisci il {i+1}o numero:\n");
                if (int.TryParse(Console.ReadLine(), out cardNumber[i]) == false)
                {
                    do
                    {
                        Console.WriteLine("Inseririsci il {i}o numero:");
                        int.TryParse(Console.ReadLine(), out cardNumber[i]);
                    }
                    while (int.TryParse(Console.ReadLine(), out cardNumber[i]) == false);
                }
                
            }

            return cardNumber;
        }

        //Crea array con numeri in posizione dispari
        private static int[] CreateOddNumbersArray(int[] cardNumber, int[] oddNumbers)
        {
            int count = 0;

            for(int i=0; i<16; i++)
            {

                if(i%2 == 0)
                {
                    oddNumbers[count] = cardNumber[i];
                    count++;
                }

            }



            return oddNumbers;
        }

        //Crea array con numeri posizione pari
        private static int[] CreateEvenNumbersArray(int[] cardNumber, int[] evenNumbers)
        {
            int count = 0;

            for (int i = 0; i < 16; i++)
            {

                if (i % 2 != 0)
                {
                    evenNumbers[count] = cardNumber[i];
                    count++;
                }

            }



            return evenNumbers;
        }

        //Crea array con i numeri in posizione dispari raddoppiati (e diminuiti di 9 se a doppia cifra)
        private static int[] DoublingOddNumbers(int[] oddNumbers, int[] doubledNumbers)
        {
            for (int i = 0; i < 8; i++) {

                doubledNumbers[i] = oddNumbers[i] * 2;

                if(doubledNumbers[i] >=10)
                {
                    doubledNumbers[i] -= 9;  
                }

            }

            return doubledNumbers; 
        }

        //Somma i numeri dell'array dispari
        private static int AddingOddNumbers(int[] doubledNumbers, ref int result)
        {

            for(int i = 0; i < 8; i++)
            {
                result += doubledNumbers[i];
            }



            return result;
        }

        //Somma tutti i numeri (posizione pari e dispari)
        private static int AddingNumbers(int[] evenNumbers, ref int result)
        {

            for(int i=0; i<8; i++)
            {
                result += evenNumbers[i];
            }

            return result;

        }

        //Controlla se la divisione per 10 ha resto uguale a zero
        private static void CheckResult(ref int result)
        {
            if (result % 10 == 0)
            {
                Console.WriteLine("Il numero della carta è valido!");
            }
            else
            {
                Console.WriteLine("Il numero della carta non è valido!");
            }
        }

    }
}
