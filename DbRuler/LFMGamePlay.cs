using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbRuler
{
    public enum TypeOfObject
    {
        Balance = 0,
        Movie = 1,
        Serial = 2,
        Script = 49,
        Writer = 50,
        Director = 51,
        Showrunner = 52,
        Actor = 60,
        Sport = 61,
        Singer = 62,
        TdP = 70,
        FX = 71
    }

    public class LastCashMovement
    {
        public int ID_Target { get; set; }
        public TypeOfObject Target { get; set; }
        public int ID_Movement { get; set; }
        public TypeOfObject TypeOfMovement { get; set; }
        public long MovementValue { get; set; }
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
        public int Week { get; set; } = 0;
    }

    // Nome PG, Nome Studios, Soldi
    // Tabella Bilanci - Riga: Valore (+o-), Tipo, ID

    public static class LFMGamePlay
    {
    }
}
