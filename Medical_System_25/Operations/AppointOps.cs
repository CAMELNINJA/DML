using Medical_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_System.Operations
{
    public static class AppointOps
    {
        private static List<Appointment> GetAppiontment(string command)
        {
            var appoint = new List<Appointment>();
            var appointObj = DataBase.Select(command);
            foreach (var a in appointObj)
                appoint.Add(new Appointment(a));
            return appoint;
        }
        
        public static List<Appointment> GetAllAppoint()
        {
            return GetAppiontment("SELECT * FROM appointment;");
        }
        private static void PostAppoint(string command)
        {
            DataBase.Select(command);
        }
        public static void PostAppoint(DateTime data,int pers,int doc)
        {
            PostAppoint("INSERT INTO appointment (data,person_id,doctor_id ) VALUES('" + data.Year + "-"+data.Month+"-"+data.Day+"', '" +pers + "', '" + doc + "')");
        }
        public static List<Appointment> GetdocAppoint(int id)
        {
            return GetAppiontment("select *from appointment where doctor_id=" + id + ";");
        }
    }
}
