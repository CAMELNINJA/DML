using Sportmag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportmag.Operations
{
    public class ChatOps
    {
        public static List<Person> GetAllChat(int id)
        {
            return GetChat("SELECT * FROM chat where sale_id="+id+";");
        }
        public static void PostChat(int sale_id,int pers_id,string text,DateTime date,string name)
        {
            PostChat("INSERT INTO chat (sale_id,person_id,text,data,name) VALUES(" + sale_id + "," + pers_id + ",'" + text + "','"+date + "','"+name+"');");
        }
        private static List<Person> GetChat(string command)
        {
            var chat = new List<Person>();
            var catobj = DataBase.Select(command);
            foreach (var c in catobj)
                chat.Add(new Person(c));
            return chat;
        }
        private static void PostChat(string command)
        {
            var chatObjs = DataBase.Select(command);
        }
    }
}

