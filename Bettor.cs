using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsCarRace
{
    public class Bettor : Bet
    {
        public string titles { get; set; }
        public int cashavailable { get; set; }
        public Bet current;

        public RadioButton selector { get; set; }
        public Label activity { get; set; }

        public void ModifyLabels()
        {
            selector.Text = titles + " has $" + cashavailable;
        }

        public void Reset()
        {
            current = null;
            activity.Text = titles + " hasn't placed a bet";
        }

        public bool PlaceTheBet(int BidAmount, int VehicleToWin)
        {
            this.current = new Bet() { Amount = BidAmount, car = VehicleToWin };

            if (BidAmount <= cashavailable)
            {
                activity.Text = this.titles + " has placed $" + BidAmount + " Bid on Car #" + VehicleToWin;
                this.ModifyLabels();
                return true;
            }
            else
            {
                MessageBox.Show(this.titles + " does not have enough cash to cover the Bid");
                this.current = null;
                return false;
            }
        }

        public void CollectYourMoney(int Winner)
        {
            if (this.current != null)
            {
                cashavailable += current.CashOutWinnings(Winner);
                Reset();
                ModifyLabels();
            }
        }
    }
}
