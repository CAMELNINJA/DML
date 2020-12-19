using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;


namespace Medical_System.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Data_Birth { get; set; }
        public string snills { get; set; }
        public string image { get; set; }
        public Person() { }
        public Person(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            Name = select[1].ToString();
            LastName = select[2].ToString();
            Data_Birth = select[3].ToString();
            snills = select[4].ToString();
            image = select[5].ToString();
        }
    }
}
