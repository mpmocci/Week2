using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public static class LibreriaManager
    {

        public static List<Libro> libri = new List<Libro>();



        public static void AggiungiDatiProva()
        {
            Libro libro1 = new Libro()
            {
                Codice = "L001",
                Titolo = "I promessi sposi",
                Autore = "Manzoni",
                Prezzo = 10,
                Genere = (Genere)1,
                DataPubblicazione = new DateTime(2010, 10, 12)
            };

            libri.Add(libro1);
        }

        public static void AggiungiLibro()
        {
            //Chiedo all'utente le informazioni necessarie per poter creare un libro.
            Libro libro = new Libro(); //un libro "vuoto".
            Console.WriteLine("Inserisci il codice del libro");
            libro.Codice = Console.ReadLine();
            Console.WriteLine("Inserisci il titolo del libro");
            libro.Titolo = Console.ReadLine();
            Console.WriteLine("Inserisci l'autore del libro");
            libro.Autore = Console.ReadLine();
            libro.Prezzo = InserisciPrezzo();
            libro.DataPubblicazione = InserisciDataPubblicazione();
            libro.Genere = InserisciGenere();

            libri.Add(libro);
            Console.WriteLine("Libro aggiunto correttamente");
        }

        private static Genere InserisciGenere()
        {
            Console.WriteLine("Inserisci il genere del libro");
            Console.WriteLine($"Premi {(int)Genere.Narrativa} per il genere {Genere.Narrativa}");
            Console.WriteLine($"Premi {(int)Genere.Storico} per il genere {Genere.Storico}");
            Console.WriteLine($"Premi {(int)Genere.Fantasy} per il genere {Genere.Fantasy}");
            int genere;
            do
            {
                Console.WriteLine("Fai la tua scelta");
            } while (!(int.TryParse(Console.ReadLine(), out genere) && genere >= 1 && genere <= 3));
            return (Genere)genere;
        }

        private static DateTime InserisciDataPubblicazione()
        {
            DateTime data;
            do
            {
                Console.WriteLine("Inserisci la data di pubblicazione del libro");
            } while (!(DateTime.TryParse(Console.ReadLine(), out data) && data <= DateTime.Today));
            return data;
        }

        private static double InserisciPrezzo()
        {
            double prezzo;
            do
            {
                Console.WriteLine("Inserisci il prezzo del libro");
            } while (!(double.TryParse(Console.ReadLine(), out prezzo) && prezzo > 0));
            return prezzo;
        }

        public static void EliminaLibro()
        {
            Console.WriteLine("I libri presenti nella libreria sono:");
            StampaLibri();
            Console.WriteLine("Scrivi il codice del libro che vuoi eliminare");
            string codiceDaRicercare = Console.ReadLine();
            Libro libroTrovato = CercaLibro(codiceDaRicercare);
            if (libroTrovato == null)
            {
                Console.WriteLine("Libro non trovato. Codice errato!");
            }
            else
            {
                libri.Remove(libroTrovato);
                Console.WriteLine("Libro eliminato correttamente!");
            }
        }

        private static Libro CercaLibro(string codice)
        {
            foreach (var item in libri)
            {
                if (item.Codice == codice)
                {
                    return item;
                }
            }
            return null;
        }


        public static void ModificaLibro()
        {
            //stampa i libri disponibili
            //seleziona il libro da modificare tramite codice
            //menù con possibili opzioni modifica
            //modifica campo desiderato

            Console.WriteLine("\nI libri presenti nella libreria sono:\n");
            StampaLibri();
            Console.WriteLine("Inserisci il codice del libro che vuoi modificare:\n");
            string codice = Console.ReadLine();
            Libro libroDaModificare= CercaLibro(codice);
            if (libroDaModificare==null)
            {
                Console.WriteLine("Libro non trovato. Inserire codice corretto.\n");
            }
            else
            {
                bool restart=true;

                do {
                    Console.WriteLine("Premi: \n" +
                        "1) per modificare il titolo\n" +
                        "2) per modificare l'autore\n" +
                        "3) per modificare il genere\n " +
                        "4) per modificare il prezzo\n" +
                        "5) per modificare la data di pubblicazione\n");

                    int scelta;

                    do
                    {
                        Console.WriteLine("Fai la tua scelta");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 1 && scelta <= 5));


                    switch (scelta)
                    {

                        case 1:

                            Console.WriteLine("Inserisci nuovo titolo");
                            libroDaModificare.Titolo = Console.ReadLine();
                            break;


                        case 2:

                            Console.WriteLine("Inserisci nuovo autore");
                            libroDaModificare.Autore = Console.ReadLine();
                            break;

                        case 3:

                            Console.WriteLine("Inserisci nuovo genere");
                            libroDaModificare.Genere = InserisciGenere();
                            break;


                        case 4:

                            Console.WriteLine("Inserisci nuovo prezzo");
                            libroDaModificare.Prezzo = InserisciPrezzo();
                            break;



                        case 5:

                            Console.WriteLine("Inserisci nuova data di pubblicazione");
                            libroDaModificare.DataPubblicazione = InserisciDataPubblicazione();
                            break;

                    }

                    Console.WriteLine("\nVuoi modificare altri dati? Premi y per continuare, qualsiasi altro tasto per uscire.\n");
                    string rimodificare=Console.ReadLine();
                    if (rimodificare != "y")
                    {
                        restart = false;
                    }
                }

                while (restart==true);


                






            }


        
        }

        public static void StampaLibriDiUnaLista(List<Libro> listaLibri)
        {
            if (listaLibri.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("Codice\t\tTitolo\t\tAutore\t\tGenere\t\tPrezzo\t\tDataPubblicazione");
                foreach (var item in listaLibri)
                {
                    Console.WriteLine($"{item.Codice}\t\t{item.Titolo}\t\t{item.Autore}\t\t{item.Genere}\t\t{item.Prezzo}\t\t{item.DataPubblicazione.ToShortDateString()}");
                }
            }
        }//stampa libri generico

        public static void StampaLibri() //stampa libri dalla nostra lista
        {
            StampaLibriDiUnaLista(libri);
        }

        public static void FiltraLibriPerGenere()
        {
            Genere g = InserisciGenere();
            List<Libro> libriFiltrati = new List<Libro>();
            foreach(var item in libri)
            {
                if (item.Genere == g)
                {

                    libriFiltrati.Add(item);

                }
            }

            StampaLibriDiUnaLista(libriFiltrati);
         }






    }
}