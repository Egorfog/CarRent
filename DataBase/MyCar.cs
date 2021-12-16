using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach1.DataBase
{
    public class MyCar
    {
        public Guid Id { get; set; }

        public double Hours { get; set; }

        public Car Car { get; set; }

        public double CalculatedRevenue()
        {
            return Math.Round(Car.CostOf1Hour * Hours, 2);
        }

        public override string ToString()
        {
            return $"{Car} {Hours}";
        }
    }
}
