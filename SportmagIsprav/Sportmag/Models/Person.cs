using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }
        public Person(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            Name = select[1].ToString();
            SeName = select[2].ToString();
        }

    }
}
