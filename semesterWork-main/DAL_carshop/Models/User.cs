using System;
using System.ComponentModel.DataAnnotations;
using DAL_carshop.Models;

namespace DAL_carshop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Second_name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        

    }
}
