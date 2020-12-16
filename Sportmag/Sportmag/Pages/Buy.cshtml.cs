using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sportmag.Models;
using Sportmag.Operations;

namespace Sportmag.Pages
{
    public class BuyModel : PageModel
    {
        List<Sale> subject;
        List<Kofs> company;
        public List<Kofs> DisplayedCompany { get; set; }
        public List<Sale> DisplayedSubject { get; set; }
        public BuyModel()
        {
            subject = SaleOps.GetAllSales();
            company = KofsOps.GetAllKofs();
        }


        public void OnGet()
        {
            DisplayedSubject = subject;
            DisplayedCompany = company;
        }
        public void OnPost(int companyId)
        {
           
            if (companyId == 0)
            {
                DisplayedSubject = subject;
                DisplayedCompany = company;
            }
            else
            {     
                DisplayedSubject = SaleOps.GetIdSales(companyId);
                DisplayedCompany = company;
            }
        }
    }
}
