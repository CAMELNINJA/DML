using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_System.Models
{
    public class Personalization
    {
        public int Id { get; set; }
        public string name { get; set; }
         public Personalization(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            name = select[1].ToString();
        }
    }
}
