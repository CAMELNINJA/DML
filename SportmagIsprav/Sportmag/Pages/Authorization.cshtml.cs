using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sportmag.Operations;
using Sportmag.Models;

namespace Sportmag.Pages.Empty
{
    public class AuthorizationModel : PageModel
    {
        public string Mesage { get; set; }
        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
        public IActionResult OnPost(string name,string sername,string login ,string pasword)
       {
            int a ;
            
            pasword = HashPassword(pasword);
            var pers = PersonOps.GetAllPerson();
            if (pers.Count!=0)
            {   
               foreach(Person p in pers)
                {
                    if((p.Name == name)&&(p.SeName==sername))
                    {
                        var auth = AuthOps.GetIdAuthorizations(p.Id);
                        if(auth.login==login)
                        {
                           
                            Mesage = "Вы уже зарегистрированы";
                            return Redirect("./Entrance");
                        }
                    }
                }
             
                
                    a = PersonOps.GetLastId();
                    PersonOps.PostPers(a,name, sername);
                    AuthOps.PostAuth(a, login, pasword);
                    Mesage = "Вы зарегистрировались удачно";
                    Response.Cookies.Append("login", login);
                    Response.Cookies.Append("id", a.ToString());
                    return Redirect("./User");
                
            }
            else
            {
                PersonOps.PostPers(0, name, sername);
                AuthOps.PostAuth(0, login, pasword);
                Mesage = "Вы зарегистрировались удачно";
                Response.Cookies.Append("login", login);
                Response.Cookies.Append("id", "0");
                return Redirect("./User");
            }
            
       }
    }
  
}
