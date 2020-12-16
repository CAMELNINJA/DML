using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Models
{
    public class Kofs
    {
        public int Id { get; set; }
        public string Kind_of_sport { get; set; }
        public Kofs(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            Kind_of_sport = select[1].ToString();
        }
    }
    
}
