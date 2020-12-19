using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
namespace Medical_System.Models
{
    public class medical_card
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Pers_id { get; set; }
        public string Person_Name { get; set; }
        public int Doc_id { get; set; }
        public string Doctor_name { get; set; }


        public medical_card(List<object> select)
        {
            Id = Convert.ToInt32(select[0].ToString());
            Text = select[1].ToString();
            Pers_id = Convert.ToInt32(select[2].ToString());
            Person_Name = select[3].ToString();
            Doc_id = Convert.ToInt32(select[4].ToString());
            Doctor_name = select[5].ToString();

        }
    }
}
