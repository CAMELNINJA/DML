using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sportmag.Models;
using Sportmag.Operations;

namespace Sportmag.Pages.Empty
{
    public class SaleModel : PageModel
    {   
        public List<Chat> chats{get;set;}
        public Sale sale { get; set; }
        public void OnGet(int Id)
        {
            
            this.sale = SaleOps.GetIdSale(Id);
            chats = ChatOps.GetAllChat(Id);
        }
        public void OnPostCommit(int Id,string text)
        {
            if (Request.Cookies["id"] != null)
            {
                ChatOps.PostChat(Id, Convert.ToInt32(Request.Cookies["id"]), text, DateTime.Now, Request.Cookies["login"]);
                chats = ChatOps.GetAllChat(Id);
                this.sale = SaleOps.GetIdSale(Id);
            }
            else
            {
                chats = ChatOps.GetAllChat(Id);
                this.sale = SaleOps.GetIdSale(Id);
            }
        }
        public IActionResult OnPostBuying(int Id)
        {
            if (Request.Cookies["id"] != null)
            {
                sale = SaleOps.GetIdSale(Id);
                if (sale.Count > 1)
                {
                    BasketOps.PostBascet(Convert.ToInt32(Request.Cookies["id"]), Id);
                    return Redirect("/User");
                }
                else
                {
                    BasketOps.PostBascet(Convert.ToInt32(Request.Cookies["id"]), Id);
 
                    return Redirect("/User");
                }
            }
            return Redirect("/Entrance");
        }
    }
}
