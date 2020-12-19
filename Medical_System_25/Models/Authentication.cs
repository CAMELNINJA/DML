using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Medical_System.Models
{
    public class Authentication
    {
        public int Pers_id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }


        public Authentication(List<object> select)
        {
            Pers_id = Convert.ToInt32(select[0].ToString());
            Login = select[1].ToString();
            Password = select[2].ToString();
        }
    }
}
