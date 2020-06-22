using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeightCalculator.ViewModel
{
    public class BmiVM
    {
        public int Height { get; set; }
        public int InitWeight { get; set; }
        public int DesiredWeight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BetterReturn WeightDif()
        {
            var Weight = new BetterReturn();
            if (InitWeight > DesiredWeight)
            {
                Weight.Text = "lose";
            }
            else
                Weight.Text = "gain";
            Weight.Value = Math.Abs(InitWeight - DesiredWeight);
            return Weight;
        }
        public BetterReturn CurrentBMI(int weight)
        {
            var currentBMI = new BetterReturn();
            currentBMI.Value  = Math.Round((weight / (Math.Pow((double.Parse(Height.ToString()) / 100), 2))),2);
            if (currentBMI.Value < 18.5)
            {
                currentBMI.Text = "Niedowaga";
            }
            else if (currentBMI.Value <= 24.9)
            {
                currentBMI.Text = "Waga prawidłowa";
            }
            else if (currentBMI.Value <= 29.9)
            {
                currentBMI.Text = "Nadwaga";
            }
            else if (currentBMI.Value > 29.9)
            {
                currentBMI.Text = "Otyłość";
            }
          
            return currentBMI;
        }
       
    }
}