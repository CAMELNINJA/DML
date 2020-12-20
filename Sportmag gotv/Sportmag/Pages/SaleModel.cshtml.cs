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
    {  int id { get; set; }
        public List<Chat> chats{get;set;}
        public Sale sale { get; set; }
        public void OnGet(int Id)
        {
            id = Id;
            this.sale = SaleOps.GetIdSale(Id);
            chats = ChatOps.GetAllChat(Id);
        }
        public void OnPost(string text)
        {
            ChatOps.PostChat(id, Convert.ToInt32(Request.Cookies["id"]), text, DateTime.Now, Request.Cookies["login"]);
            chats = ChatOps.GetAllChat(id);
            this.sale = SaleOps.GetIdSale(id);
        }
    }
}
