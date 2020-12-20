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
        public List<Basket> baskets{get;set; } = new List<Basket>();
        public List<Sale> sale { get; set; } = new List<Sale>();
        
        public void OnGet()
        { 
            if (Request.Cookies["id"] != null)
            {
                var a = Request.Cookies["id"];
                GetPerson = PersonOps.GetIdPerson(Convert.ToInt32(a));
                baskets = BasketOps.GetIdBascet(Convert.ToInt32(a));
                foreach (var bas in baskets)
                    sale.Add(SaleOps.GetIdSale(bas.sale_id));

            }
            else
            {
                GetPerson = new Person();
                GetPerson.Name = "Ваше имя";
                GetPerson.SeName = "Ваша Фамилия";
            }

        }
        public IActionResult OnPost()
        {
            if (Request.Cookies["id"] != null)
                Response.Cookies.Delete("id");
            if (Request.Cookies["login"] != null)
                Response.Cookies.Delete("login");
            return Redirect("./Buy");
        }
        public void OnPostBuy()
        {
            var a = Request.Cookies["id"];
            baskets = BasketOps.GetIdBascet(Convert.ToInt32(a));
            foreach(var bas in baskets)
            {
                var sal = SaleOps.GetIdSale(bas.sale_id);
                if (sal.Count > 1)
                {
                    BasketOps.PostDeletBascet(Convert.ToInt32(a));
                    SaleOps.PostSale(bas.sale_id);
                }
                else
                {
                    BasketOps.PostDeletBascet(Convert.ToInt32(a));
                    SaleOps.PostIdSale(bas.sale_id);
                }
            }
            GetPerson = PersonOps.GetIdPerson(Convert.ToInt32(a));
            baskets = BasketOps.GetIdBascet(Convert.ToInt32(a));
        }

    }
}
