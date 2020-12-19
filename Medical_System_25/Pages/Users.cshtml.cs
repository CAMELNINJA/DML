using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical_System.Models;
using Medical_System.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medical_System.Pages
{
    public class UsersModel : PageModel
    {
        public Person Person { get; set; }
        public UsersModel()
        {

        }

        public void OnGet()
        {
            if (Request.Cookies["id"] != null)
            {
                var a = Request.Cookies["id"];
                Person = PersonOps.GetIdPerson(Convert.ToInt32(a));
            }
            {
                Person = new Person();
                Person.Id = 0;
                Person.Name = "Имя";
                Person.LastName = "Фамилия";
            }
        }
        public IActionResult OnPost()
        {
            if (Request.Cookies["id"] != null)
            {
                Response.Cookies.Delete("id");
                Response.Cookies.Delete("login");
                Response.Cookies.Delete("csrftoken");
            }
            Person = null;
            return Redirect("./Index");
        }
    }
}
