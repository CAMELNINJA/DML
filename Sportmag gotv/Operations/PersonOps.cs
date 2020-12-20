using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sportmag.Models;
namespace Sportmag.Operations
{
    public static class PersonOps
    {
        public static Person GetIdPerson(int Id)
        {
            return GetPerson("SELECT * FROM person WHERE id = " + Id + " LIMIT 1;").FirstOrDefault();
        }
        private static List<Person> GetPerson(string command)
        {
            var person = new List<Person>();
            var personObjs = DataBase.Select(command);
            foreach (var per in personObjs)
                person.Add(new Person(per));
            return person;
        }
        public static List<Person> GetAllPerson()
        {
            return GetPerson("SELECT * FROM person");
        }
        public static int GetLastId()
        {
            return GetPerson("SELECT *FROM person").LastOrDefault().Id + 1;
        }
        private static void PostPers(string command)
        {
            var personObjs = DataBase.Select(command);
        }
        public static void PostPers(int id,string name,string sename)
        {
            PostPers("INSERT INTO person (id,first_name,last_name )VALUES(" + id + ",'" + name + "','" + sename + "')");
        }
    }
}
