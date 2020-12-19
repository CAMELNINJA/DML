using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medical_System.Models;
using Medical_System.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Medical_System.Pages
{
    public class IndexModel : PageModel
    {
        public List<Doctor> doc = new List<Doctor>();



         public void OnPost(string search)
        {
            if (search != null)
            {
                doc = DoctorOps.GetSearchDoctor(search);
            }
        }

    }
}
