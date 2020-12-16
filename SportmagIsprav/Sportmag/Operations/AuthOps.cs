using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sportmag.Models;

namespace Sportmag.Operations
{
    public static class AuthOps
    {
        public static List<Authorization> GetAuthorization(string login) 
        {
            return GetAuthorizations("SELECT * FROM authentication WHERE login = '" + login + "';");
        }
        public static List<Authorization>GetAllAuthorizations()
        {
            return GetAuthorizations("SELECT * FROM authentication");
        }
        public static Authorization GetIdAuthorizations(int Id)
        {
            return GetAuthorizations("SELECT * FROM authentication WHERE pers_id = " + Id + " LIMIT 1;").FirstOrDefault();
        }
        public static void PostAuth(int id, string login, string pasword)
        {
            PostAuthorization("INSERT INTO authentication (pers_id,login,pasword) VALUES(" + id + ",'" + login + "','" + pasword + "')");

        }
        private static List<Authorization> GetAuthorizations(string command)
        {
            var Auth = new List<Authorization>();
            var aythObjs = DataBase.Select(command);

            foreach (var sale in aythObjs)
                Auth.Add(new Authorization(sale));

            return Auth;
        }
        private static void PostAuthorization(string command)
        {
            var Auth = DataBase.Select(command);
        }
        
        
        
    }
}

