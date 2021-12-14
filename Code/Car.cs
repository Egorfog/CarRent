using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach1
{
    public abstract class Car
    {
        public Guid Id { get; set; }
        public string CarBrand { get; set; }
        public int YearOfIssue { get; set; }
        public int Mileage { get; set; }
        public double CostOf1Hour { get; set; }
        //public abstract double CalculatedRevenue(double hours);
    }
}
