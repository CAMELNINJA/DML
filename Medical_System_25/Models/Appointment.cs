using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_System.Models
{
    public class Appointment
    {
        public int person_id { get; set; }
        public int doctor_id { get; set; }
        public DateTime data { get; set; }
        public Appointment(List<object> select)
        {
            data = Convert.ToDateTime(select[0].ToString());
            doctor_id = Convert.ToInt32(select[1].ToString());
            person_id = Convert.ToInt32(select[2].ToString());
        }
    }
}
