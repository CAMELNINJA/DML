using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Models
{
    public class Basket
    {
        public int per_id {get;set;}
        public  int sale_id { get; set; }
        public int count { get; set; }

        public Basket(List<object> select)
        {
            per_id = Convert.ToInt32(select[0].ToString());
            sale_id = Convert.ToInt32(select[1].ToString());
            count = Convert.ToInt32(select[2].ToString());
        }
    }
}
