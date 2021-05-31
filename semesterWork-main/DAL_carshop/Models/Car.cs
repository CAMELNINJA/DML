using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL_carshop.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Mark_car { get; set; }
        public string Name_car { get; set; }
        public double Price_car { get; set; }
        public int Discount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
