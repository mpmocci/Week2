using System;
using System.IO;


namespace Day7_InputOutputDaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Si crea una stringa con il path del file sul quale si vuole registrare l'output
            //bisogna aggiungere alla fine del path \FileProva.txt, ovvero il nome del file dove registrare l'output

            string path = @"C:\Users\paola\source\repos\Week2\Day7_InputOutputDaFile\Day7_InputOutputDaFile\FileProva.txt";
            //StreamWriter sw = new StreamWriter(@"FileProva.txt"); //senza path viene salvato di default nella cartella bin del progetto

            /******Scrittura su file con CHIUSURA MANUALE******/

            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Hola");
            sw.Close(); // chiusura manuale


            /*******Scrittura su file con CHIUSURA AUTOMATICA****/
            //si usa using

            //Scrittura automatica su file SOVRASCRIVENDO CONTENUTO PRECEDENTE

            using(StreamWriter sw1= new StreamWriter(path))
            {
                sw1.WriteLine("Hello");
            }


            //Scrittura automatica su file SENZA SOVRASCRIVERE

            using (StreamWriter sw1 = new StreamWriter(path, true))
            {
                sw1.WriteLine("World");
            }

            //******************LETTURA DI UN FILE************//

            //Lettura di tutto il file
            using(StreamReader sw1 = new StreamReader(path))
            {
                string fileContent = sw1.ReadToEnd(); // restituisce tutti i caratteri in una stringa
                var arrayOfLines = fileContent.Split("\r \n"); // separa tutto il contenuto del file in base alle righe (quindi quando si incontrano i caratteri dentro le parentesi)
            }



            //Lettura di una riga
            using (StreamReader sw1 = new StreamReader(path))
            {
                string fileContent = sw1.ReadLine();
            }

        }

    }
}
