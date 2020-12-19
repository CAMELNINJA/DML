using Medical_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Medical_System.Operations
{
    public static class DoctorOps
    {
        private static List<Doctor> GetDoctors(string command)
        {
            var doctor = new List<Doctor>();
            var doctorObj = DataBase.Select(command);
            foreach (var doc in doctorObj)
            {
                doctor.Add(new Doctor(doc));
            }
            return doctor;
        }
        public static List<Doctor> GetAllDoctor()
        {
            return GetDoctors("SELECT * FROM doctor;");
        }
        public static Doctor GetIdDoctor(int id)
        {
            return GetDoctors("SELECT * FROM doctor WHERE id=" + id + ";").FirstOrDefault();
        }
        public static List<Doctor> GetSearchDoctor(string search)
        {
            return GetAllDoctor().Where(s => Regex.IsMatch((s.Name + s.LastName + s.location_hospital+s.personalization+s.hospital_name).ToLower(), Regex.Replace(search, @"[^\d\w]", "").ToLower())).ToList();
        }
    }

}
