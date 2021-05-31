using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL_carshop.Models
{
    
    public class Orders
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Car_Id { get; set; }
        public double Sum_Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
