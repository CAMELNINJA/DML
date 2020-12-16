using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Models
{
    public class Sale
    {
        public Sale(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            Name = select[1].ToString();
            Price = Convert.ToDouble(select[2].ToString());
            Count = Convert.ToInt32(select[3].ToString());
            Kind_of_sport = select[4].ToString();
            company_Id = Convert.ToInt32(select[5].ToString());
            image = select[6].ToString();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Kind_of_sport { get; set; }
        public int company_Id { get; set; }
        public string image { get; set; }

        
    }

}
