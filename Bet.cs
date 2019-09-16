using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCarRace
{
    public class Bet : Car
    {
        public int Amount { get; set; }
        public Bettor bettor { get; set; }
        public int car { get; set; }
        public int multiplier { get; set; }

        public int CashOutWinnings(int Winner)
        {
            if (Winner == car)
            {
                return Amount * 2;
            }
            else
            {
                return (0 - Amount);
            }
        }
    }
}
