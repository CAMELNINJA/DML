using System;
using System.Collections.Generic;
using System.Text;
using DAL_carshop.Models;
namespace DAL_carshop.SeedData
{
     public class SeedCar
    {

        private List<Car> _cars { get; set; } 

        public List<Car> DataCar()
        {
            if (_cars == null)
            {
                CreateCar();
            }
            return _cars;
        }
        
        private void CreateCar()
        {
            _cars = new List<Car>();
            _cars.Add( new Car { Id = 0, Mark_car = "Lorem", Name_car = "Ipsum", Price_car = 140 });
            _cars.Add(new Car { Id = 1, Mark_car = "Lorem", Name_car = "Ipsum", Price_car = 100 });
            _cars.Add(new Car { Id = 2, Mark_car = "Lorem", Name_car = "Ipsum", Price_car = 50 });
            _cars.Add(new Car { Id = 0, Mark_car = "Lorem", Name_car = "Ipsum", Price_car = 140 });

        }
    }
}
