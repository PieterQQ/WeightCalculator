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
        public BetterReturn BmiCalc(int weight)
        {
            var currentBMI = new BetterReturn();
            currentBMI.Value  = Math.Round((weight / (Math.Pow((double.Parse(Height.ToString()) / 100), 2))),2);
            if (currentBMI.Value < 15)
            {
                currentBMI.Text = "Very severely underweight";
            }
           else if (currentBMI.Value < 16)
            {
                currentBMI.Text = "Severely underweight";
            }
            else if(currentBMI.Value <= 18.5)
            {
                currentBMI.Text = "Underweight";
            }
            else if (currentBMI.Value < 25)
            {
                currentBMI.Text = "Normal";
            }
            else if (currentBMI.Value < 30)
            {
                currentBMI.Text = "Overweight";
            }
            else if (currentBMI.Value < 35)
            {
                currentBMI.Text = "Moderately obese";
            }
            else if (currentBMI.Value <= 40)
            {
                currentBMI.Text = "Severely obese";
            }
            else if (currentBMI.Value > 40)
            {
                currentBMI.Text = "Very severely obese";
            }

            return currentBMI;
        }
        private int GetDays()
        {
            return Math.Abs(EndDate.Day - StartDate.Day);
        }
        private double GetWeeks()
        {
            var xd =(EndDate.Date - StartDate.Date).TotalDays / 7;
            return xd;
        }
        public BetterReturn KilosPerDay()
        {
            var KilosPerDay = new BetterReturn();
            if (InitWeight > DesiredWeight)
                KilosPerDay.Text = "lose";
            else
                KilosPerDay.Text = "gain";
            KilosPerDay.Value = Math.Round(double.Parse(Math.Abs(InitWeight - DesiredWeight).ToString()) / double.Parse(GetDays().ToString()),2);
            return KilosPerDay;
        }
        public BetterReturn KilosPerWeek()
        {
            var KilosPerWeek = new BetterReturn();
            if (GetWeeks() >= 1)
            {
                if (InitWeight > DesiredWeight)
                    KilosPerWeek.Text = "You should lose";
                else
                    KilosPerWeek.Text = "You should gain";
                KilosPerWeek.Value = Math.Round(double.Parse(Math.Abs(InitWeight - DesiredWeight).ToString())
             / double.Parse(GetWeeks().ToString()), 2);
                KilosPerWeek.Unit = "kg per week";
            }
          

         
            return KilosPerWeek;
        }
    }
}