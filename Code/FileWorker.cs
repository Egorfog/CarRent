using System;
using System.IO;
using System.Text;


namespace Kursach1
{
    public class FileWorker
    {
        private static CarPark carPark;

        public static CarPark GetCarPark()
        {
            if (carPark == null)
            {
                var carPark = new CarPark();
                var text = File.ReadAllText(@"cars.txt");
                using (var stringReader = new StringReader(text))
                {
                    string line;
                    while ((line = stringReader.ReadLine()) != null)
                    {
                        var parameters = line.Split(' ');

                        carPark.Cars.Add(new RentCar(
                            carBrand: parameters[0],
                            yearOfIssue: Convert.ToInt32(parameters[1]),
                            mileage: Convert.ToInt32(parameters[2]),
                            costOf1Hour: Convert.ToDouble(parameters[3])));
                    }
                }

                return carPark;
            }

            return carPark;
        }
    }
}
