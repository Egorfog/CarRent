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

        public override string ToString()
        {
            return $"{CarBrand} {YearOfIssue} {Mileage} {CostOf1Hour}";
        } 
    }
}
