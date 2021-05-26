using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.BolletteClassi
{
    class Utente
    {
        public String CodiceUtente { get; set; } = "XXXXX";
        public String Nome { get; set; } = "XXXXXX";
        public String Cognome { get; set; } = "XXXXXX";
        public DateTime DataNascita { get; set; } = new DateTime(2000, 1, 1);

        public String ToString()
        {
            return $"Codice Utente: {CodiceUtente} Nome: {Nome} - Cognome: {Cognome} - " +
                $"Data di nascita: {DataNascita.ToShortDateString()}";
        }

    }
}
