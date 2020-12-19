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
    public class DoctorModel : PageModel
    {
        public List<Chat> chats { get; set; }
        public List<Appointment> appointment { get; set; }
        public string Messege { get; set; }
        public Doctor doctor { get; set; }
        public void OnGet(int Id)
        {
            chats = ChatOps.GetAllChat(Id);
            Messege ="Записаться к врачу";
            doctor = DoctorOps.GetIdDoctor(Id);
        }
        public IActionResult OnPostZappis(int Id)
        {
            if (Request.Cookies["id"] != null)
            {
                appointment = AppointOps.GetdocAppoint(Id);
                if (appointment.Count < 50)
                {
                    Messege = "Вы записались к врачу";
                    AppointOps.PostAppoint(DateTime.Now.AddDays(7), Convert.ToInt32(Request.Cookies["id"]), Id);
                   
                }
                else
                {
                    Messege = "Запись закрыта";
                }
            }
            else
            {
                Messege = "Войдите в аккаунт";
            }

            chats = ChatOps.GetAllChat(Id);
            doctor = DoctorOps.GetIdDoctor(Id);
            return Content(Messege);
        }
        public void OnPostGreaterThan (int Id, string text)
        {
            if (Request.Cookies["id"] != null)
            {
                ChatOps.PostChat(Id, Convert.ToInt32(Request.Cookies["id"]), text, DateTime.Now, Request.Cookies["login"]);
            }
            chats = ChatOps.GetAllChat(Id);
            doctor = DoctorOps.GetIdDoctor(Id);
            Messege = "Записаться к врачу";

        }
    }
}
