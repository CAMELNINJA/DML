using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sportmag.Models;
using System.Text.RegularExpressions;
using Sportmag.Operations;

namespace Sportmag.Pages
{
    public class IndexModel : PageModel
    {
        public List<Sale> sales = new List<Sale>();
        public void OnPost(string search)
        {
            if (search != null)
            {
                sales = SaleOps.GetSearchSales(search);
            }
        }
    }
}
