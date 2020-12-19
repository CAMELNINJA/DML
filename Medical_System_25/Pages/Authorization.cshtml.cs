using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Medical_System.Models;
using Medical_System.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medical_System.Pages
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
        public IActionResult OnPost(string name, string sername, string login, string password)
        {
            int a = 0;

            password = HashPassword(password);
            var pers = PersonOps.GetAllPerson();
            if (pers.Count != 0)
            {
                foreach (Person p in pers)
                {
                    
                        var auth = AuthenticationOps.GetIdAuthorizations(p.Id);
                    if (auth.Login == login)
                    {
                        
                        Mesage = "Вы уже зарегистрированы";
                        return Redirect("./Entrance");
                    }
                }
                
                
                    a = PersonOps.GetLastId();
                    PersonOps.PostPers(a, name, sername);
                    AuthenticationOps.PostAuth(a, login, password);
                    Mesage = "Вы зарегистрировались удачно";
                Response.Cookies.Append("login", login);
                Response.Cookies.Append("id", a.ToString());
                return Redirect("./Users");
                
            }
            else
            {
                PersonOps.PostPers(0, name, sername);
                AuthenticationOps.PostAuth(0, login, password);
                Mesage = "Вы зарегистрировались удачно";
                Response.Cookies.Append("login", login);
                Response.Cookies.Append("id", a.ToString());
                return Redirect("./Users");
            }
        }
    }
}
