using System;
using System.Collections.Generic;
using System.Text;

namespace Paola_Mocci_TestWeek2
{
    public class Task
    {

        public string Descrizione { get; set; }
        public DateTime DataScadenza { get; set; }
        public Priorità LivelloPriorità { get; set; }


        public Task()
        {

        }


    }

    public enum Priorità
    {
        Bassa = 1,
        Media = 2,
        Alta = 3
    }
}
