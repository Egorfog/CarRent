using System;

namespace Kursach1
{
    public class RentCar : Car
    {
        public RentCar(string carBrand, int yearOfIssue, int mileage, double costOf1Hour)
        {
            CarBrand = carBrand;
            YearOfIssue = yearOfIssue;
            Mileage = mileage;
            CostOf1Hour = costOf1Hour;
        }

        //public double Hours { get; set; }

        //public override double CalculatedRevenue(double Hours)
        //{
        //    return Math.Round(CostOf1Hour * Hours, 2);
        //}

        public override string ToString()
        {
            return $"{CarBrand} {YearOfIssue} {Mileage} {CostOf1Hour}";
        } 
    }
}
