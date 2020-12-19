using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Medical_System.Models;

namespace Medical_System.Operations
{
    public class AuthenticationOps
    {
        public static List<Authentication> GetAuthorization(string login)
        {
            return GetAuthorizations("SELECT * FROM authentication WHERE login = '" + login + "';");
        }
        public static List<Authentication> GetAllAuthorizations()
        {
            return GetAuthorizations("SELECT * FROM authentication");
        }
        public static Authentication GetIdAuthorizations(int Id)
        {
            return GetAuthorizations("SELECT * FROM authentication WHERE pers_id = " + Id + " LIMIT 1;").FirstOrDefault();
        }
        public static void PostAuth(int id, string login, string pasword)
        {
            PostAuthorization("INSERT INTO authentication (pers_id,login,password) VALUES(" + id + ",'" + login + "','" + pasword + "')");

        }
        private static List<Authentication> GetAuthorizations(string command)
        {
            var Auth = new List<Authentication>();
            var aythObjs = DataBase.Select(command);

            foreach (var a in aythObjs)
                Auth.Add(new Authentication(a));

            return Auth;
        }
        private static void PostAuthorization(string command)
        {
            var Auth = DataBase.Select(command);
        }
    }
}
