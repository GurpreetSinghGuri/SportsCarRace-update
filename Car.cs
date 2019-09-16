using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsCarRace
{
    public class Car // This function is for car positioning //
    {
        public int startPos { get; set; }
        public int finishPos { get; set; }
        public PictureBox img { get; set; } // This is picture box //   
        private Random randomizer = new Random(); // This is a random function for car race //

        public bool MoveCar()   //This function is for racing//
        {
            Point currentPosition = img.Location;
            currentPosition.X += randomizer.Next(1, 6);
            img.Location = currentPosition;

            if (currentPosition.X >= finishPos)
                return true;
            else
                return false;
        }

        public void ResetPos()  // This function will start again //
        {
            img.Left = startPos;
        }
    }
}
