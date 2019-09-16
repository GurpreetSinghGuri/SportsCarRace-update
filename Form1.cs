using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsCarRace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int StartRace = Car1.Left;
            int RaceTrackLength = TrackLength.Width - Car1.Right;

            Data.allCars[0] = new Car() { img = Car1, finishPos = RaceTrackLength, startPos = StartRace };
            Data.allCars[1] = new Car() { img = Car2, finishPos = RaceTrackLength, startPos = StartRace };
            Data.allCars[2] = new Car() { img = Car3, finishPos = RaceTrackLength, startPos = StartRace };
            Data.allCars[3] = new Car() { img = Car4, finishPos = RaceTrackLength, startPos = StartRace };

            Data.Bettors[0] = new Bettor() { cashavailable = 50, activity = label1, selector = radioButton1, titles = "Player 1" };
            Data.Bettors[1] = new Bettor() { cashavailable = 50, activity = label2, selector = radioButton2, titles = "Player 2" };
            Data.Bettors[2] = new Bettor() { cashavailable = 50, activity = label3, selector = radioButton3, titles = "Player 3" };

            // Sets the default values to the labels
            Data.Bettors[0].ModifyLabels();
            Data.Bettors[1].ModifyLabels();
            Data.Bettors[2].ModifyLabels();
            Data.Bettors[0].Reset();
            Data.Bettors[1].Reset();
            Data.Bettors[2].Reset();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Data.Bettors[Data.currentgamb].PlaceTheBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Data.Bettors[Data.currentgamb].ModifyLabels();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button2.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Data.allCars.Length; i++)
            {
                Data.allCars[Data.randoms.Next(0, 4)].MoveCar();
                if (Data.allCars[i].MoveCar())
                {
                    timer1.Stop();
                    timer1.Enabled = false;
                    button2.Enabled = true;
                    DeclareWinner(i + 1);
                }
            }
        }

        private void ResetPositions()
        {
            Data.allCars[0].ResetPos();
            Data.allCars[1].ResetPos();
            Data.allCars[2].ResetPos();
            Data.allCars[3].ResetPos();
        }

        private void ResetBids()
        {
            label2.Text = "Player 1 hasn't placed a bet.";
            label2.Text = "Player 2 hasn't placed a bet.";
            label2.Text = "Player 3 hasn't placed a bet.";
        }

        private void DeclareWinner(int Winner)
        {
            MessageBox.Show("Car #" + Winner + " is the Winning Car");
            for (int i = 0; i < Data.Bettors.Length; i++)
            {
                Data.Bettors[i].CollectYourMoney(Winner);
                Data.Bettors[i].ModifyLabels();
                ResetPositions();
                ResetBids();
            }
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Data.currentgamb = 0;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Data.currentgamb = 1;
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Data.currentgamb = 2;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
