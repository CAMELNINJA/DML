using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Medical_System.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }


        public Hospital(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            Name = select[1].ToString();
            Location = select[2].ToString();
        }

    }
}
