using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;

namespace Kursach1.DataBase
{
    public class DataBaseHelper
    {
        private const string DbCars = @"Cars.db";

        private const string TableRentCars = @"rentCar";
        private const string TableMyCars = @"MyCars";

        public static void AddCar(RentCar rentCar)
        {
            using (var db = new LiteDatabase(DbCars))
            {
                var col = db.GetCollection<RentCar>(TableRentCars);
                
                col.Insert(rentCar);
            }
        }

        public static List<RentCar> GetCars()
        {
            using (var db = new LiteDatabase(DbCars))
            {
                var col = db.GetCollection<RentCar>(TableRentCars);

                var result = col.FindAll();

                return result.ToList();
            }
        }

        public static void DeleteCar(RentCar rentCar)
        {
            using (var db = new LiteDatabase(DbCars))
            {
                var col = db.GetCollection<RentCar>(TableRentCars);

                col.Delete(rentCar.Id);
            }
        }

        public static void RentCar(MyCar myCar)
        {
            using (var db = new LiteDatabase(DbCars))
            {
                var col = db.GetCollection<MyCar>(TableMyCars);

                col.Insert(myCar);
            }
        }

        public static void TakeOffRentCar(MyCar myCar)
        {
            using (var db = new LiteDatabase(DbCars))
            {

                var col = db.GetCollection<MyCar>(TableMyCars);

                col.Delete(myCar.Id);
            }
        }

        public static List<MyCar> GetMyCars()
        {
            using (var db = new LiteDatabase(DbCars))
            {
                var col = db.GetCollection<MyCar>(TableMyCars);

                var result = col.FindAll();

                return result.ToList();
            }
        }
    }
}
