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
    public class Our_DoctorsModel : PageModel
    {
       
        public List<Doctor> Doctors { get; set; }
         
        public void OnGet()
        {
            Doctors = DoctorOps.GetAllDoctor();
        }
        
    }
}