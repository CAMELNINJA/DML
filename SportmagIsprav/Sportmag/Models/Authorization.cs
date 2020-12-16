using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Models
{
    public class Authorization
    {
        public int per_Id { get; set; }
        public string login { get; set; }
        public string pasword { get; set; }
        public Authorization (List<object> select) 
        {
            per_Id = Convert.ToInt32(select[0].ToString());
            login = select[1].ToString();
            pasword = select[2].ToString();

        }

    }
}
