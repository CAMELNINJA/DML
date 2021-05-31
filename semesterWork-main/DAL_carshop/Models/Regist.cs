using System.ComponentModel.DataAnnotations;

namespace DAL_carshop.Models
{
    public class Regist
    {

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
