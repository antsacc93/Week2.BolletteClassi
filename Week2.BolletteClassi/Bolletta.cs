using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2.BolletteClassi
{
    enum TipoBolletta
    {
        Corrente,
        Gas,
        Telefono
    }

    enum UnitaMisura
    {
        kwh,
        mc,
        min
    }

    class Bolletta
    {
        private static double ImportoBase = 40;
        private static double MoltiplicativoBase = 10;
        public double ConsumoTotale { get; set; }
        public DateTime DataScadenza { get; set; } = new DateTime(2000, 1, 1);
        private double Importo { get { return GetImporto(); } }
        public Utente Utente { get; set; } //= new Utente();
        public TipoBolletta Tipologia {get; set; }

        public UnitaMisura UM { get { return GetUnitaMisura(); } }

        private double GetImporto()
        {
            return Bolletta.ImportoBase + (ConsumoTotale * Bolletta.MoltiplicativoBase);
        }

        private UnitaMisura GetUnitaMisura()
        {
            if(Tipologia == TipoBolletta.Corrente)
            {
                return UnitaMisura.kwh;
            } else if(Tipologia == TipoBolletta.Gas)
            {
                return UnitaMisura.mc;
            }else
            {
                return UnitaMisura.min;
            }
        }

        public String ToString()
        {
            return $"Utenza: {Tipologia.ToString()} - Data Scadenza: {DataScadenza.ToShortDateString()} \n" +
                $"Per un consumo di {ConsumoTotale} {UM.ToString()}: {Importo} euro \n" +
                $"Da fattura a: \n {Utente.ToString()}";
        }
    }
}
