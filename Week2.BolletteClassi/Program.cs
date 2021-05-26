using System;

namespace Week2.BolletteClassi
{
    class Program
    {
        private static Utente utente = new Utente();
        private static Bolletta bolletta = new Bolletta();
        static void Main(string[] args)
        {
            bool continua = true;
            int selezione;
            while(continua)
            {
                selezione = SchermoMenu();
                SchermoVerifica(selezione, ref continua);
                
            } 
        }

        public static int SchermoMenu()
        {
            Console.WriteLine("1. Inserisci i dati");
            Console.WriteLine("2. Stampa bolletta");
            Console.WriteLine("3. Esci");
            int scelta = Convert.ToInt32(Console.ReadLine());
            return scelta;
        }

        public static void SchermoVerifica(int selezione, ref bool continua)
        {
            switch (selezione)
            {
                case 1:
                    SchermoInserimentoDatiUtente();
                    SchermoInserimentoDatiBolletta();
                    break;
                case 2:
                    SchermoStampaDettagli();
                    break;
                default:
                    continua = false;
                    break;
            }
        }

        public static void SchermoInserimentoDatiBolletta()
        {
            Console.WriteLine("Inserisci tipologia bolletta");
            int[] values = new int[] { 0, 1, 2 };
            foreach(var item in values)
            {
                Console.WriteLine(Enum.GetName(typeof(TipoBolletta), item));
            }
            try
            {
                Enum.TryParse(Console.ReadLine(), out TipoBolletta tipo);
                bolletta.Tipologia = tipo;
                Console.Write($"Consumo in {bolletta.UM} \t ");
                bool esitoConsumo = InserimentoConsumo(out double consumo);
                while (!esitoConsumo) {
                    Console.WriteLine("Inserisci un valore numerico");
                    esitoConsumo = InserimentoConsumo(out consumo);
                }
                bolletta.ConsumoTotale = consumo;
                //bolletta.ConsumoTotale = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Inserisci data di scadenza");
                //bolletta.DataScadenza = Convert.ToDateTime(Console.ReadLine());
                bool esito = DateTime.TryParse(Console.ReadLine(), out DateTime scadenza);
                while (!esito)
                {
                    Console.WriteLine("Inserisci una data coerente");
                    esito = DateTime.TryParse(Console.ReadLine(), out scadenza);
                }
                bolletta.DataScadenza = scadenza;
                bolletta.Utente = utente;
            }
            catch (FormatException)
            {
                Console.WriteLine("Inserisci un consumo numerico");
            }
            catch (Exception)
            {
                Console.WriteLine("Ops, c'è stato un errore");
            }
            
        }

        public static bool InserimentoConsumo(out double consumo)
        {
            bool esito;
            
            try
            {
                consumo = Convert.ToDouble(Console.ReadLine());
                esito = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Errore di inserimento");
                consumo = 0.0;
                esito = false;
            }
            
            return esito;
        }

        public static void SchermoInserimentoDatiUtente()
        {
            Console.Write("Inserisci il tuo codice utente \t");
            utente.CodiceUtente = Console.ReadLine();
            Console.Write("Inserisci il tuo nome \t ");
            utente.Nome = Console.ReadLine();
            Console.Write("Inserisci il tuo cognome \t");
            utente.Cognome = Console.ReadLine();
            Console.Write("Inserisci la tua data di nascita \t");
            bool success = DateTime.TryParse(Console.ReadLine(), out DateTime data);
            //verifico il formato della data fino a quando
            //l'utente non inserisce un valore corretto
            while (!success)
            {
                Console.WriteLine("Inserisci una data corretta");
                success = DateTime.TryParse(Console.ReadLine(), out data);
            }
            utente.DataNascita = data;
        }

        public static void SchermoStampaDettagli()
        {
            if(bolletta.Utente == null)
            {
                Console.WriteLine("Nessun dettaglio inserito");
                return;
            }
            Console.WriteLine("I dati della tua bolletta");
            Console.WriteLine(bolletta.ToString());
        }
    }
}
