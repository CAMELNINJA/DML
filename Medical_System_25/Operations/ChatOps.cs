using System;
using System.Collections.Generic;
using Medical_System.Models;

namespace Medical_System.Operations
{
    public class ChatOps
    {
        public static List<Chat> GetAllChat(int id)
        {
            return GetChat("SELECT * FROM chat where doctor_id=" + id + ";");
        }
        public static void PostChat(int sale_id, int pers_id, string text, DateTime date, string name)
        {
            PostChat("INSERT INTO chat (doctor_id,person_id,text,data,name) VALUES(" + sale_id + "," + pers_id + ",'" + text + "','" + date + "','" + name + "');");
        }
        private static List<Chat> GetChat(string command)
        {
            var chat = new List<Chat>();
            var catobj = DataBase.Select(command);
            foreach (var c in catobj)
                chat.Add(new Chat(c));
            return chat;
        }
        private static void PostChat(string command)
        {
            var chatObjs = DataBase.Select(command);
        }
    }
}
