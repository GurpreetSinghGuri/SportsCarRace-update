using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCarRace
{
    abstract class Data
    {
        public static Car[] allCars = new Car[4];
        public static Bettor[] Bettors = new Bettor[3];
        public static Random randoms = new Random();
        public static int currentgamb { get; set; }
    }
}
