using DAL_carshop.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_carshop.SeedData
{
    public class SeedUser
    {
        private List<User> User { get; set; }
        private List<Role> Role { get; set; }
        public SeedUser()
        {
            if(User==null || Role == null)
            {
                User = new List<User>();
                Role = new List<Role>();
                CreateUser();
            }

        }
        public List<User> GetUsers()
        {
            if (User == null)
            {
                CreateUser();
            }
            return User;
        }
        public List<Role> GetRoles()
        {
            if (Role==null)
            {
                CreateUser();
            }
            return Role;
        }
        private void CreateUser()
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            Role adminRole = new Role { Id = 0, Name = adminRoleName };
            Role userRole = new Role { Id = 1, Name = userRoleName };
            User adminUser = new User { Id = 0,First_name="Admin",Second_name = "Admin", Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            if (Role.Count == 0)
            {
                Role.Add(adminRole);
                Role.Add(userRole);
            }
            if (User.Count == 0)
            {
                User.Add(adminUser);
            }
            
        } 
        public void SetUser(User user)
        {
            User.Add(user);
        }
    }
}
