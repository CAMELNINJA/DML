using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using Sportmag.Models;
using Sportmag.Operations;

namespace Sportmag.Pages
{
    public class UserModel : PageModel
    {
        public Person GetPerson { get; set; }
       
        public void OnGet()
        {
            var a = Request.Cookies["id"];
            GetPerson = PersonOps.GetIdPerson(Convert.ToInt32(a));

        }
        public IActionResult OnPost()
        {
            //Request.Cookies.Delet
            return Redirect("./Buy");
        }

    }
}
