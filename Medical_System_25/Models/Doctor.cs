using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_System.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int personalization_id { get; set; }
        public string personalization { get; set; }
        public int hospital_id { get; set; }
        public string hospital_name { get; set; }
        public string location_hospital { get; set;}
        public DateTime timeStart { get; set; }
        public DateTime timeStop { get; set; }
        public string image { get; set; }
        public Doctor(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            Name = select[1].ToString();
            LastName = select[2].ToString();
            personalization = select[3].ToString();
            personalization_id = Convert.ToInt32(select[4].ToString());
            hospital_name = select[5].ToString();
            hospital_id = Convert.ToInt32(select[6].ToString());
            location_hospital = select[7].ToString();
            timeStart = Convert.ToDateTime(select[8].ToString());
            timeStop = Convert.ToDateTime(select[9].ToString());
            image = select[10].ToString();
        }

    }
}
