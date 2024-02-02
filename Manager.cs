﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebSiteBlueMVVM
{
    public static class Manager
    {
        static List <User> Users = new List <User> ();
        public static void AddUser(string name, string email, string pass)
        {
            Users.Add(new User { Name = name, Email = email , Password = pass});
        }
        static string GetName(int index)
        {
            return Users[index].Name;
        }
        static string GetEmail(int index)
        {
            return Users[index].Email;
        }
        static public int GetIndex(string email)
        {
            if (Users.Contains(new User { Email = email })) 
            {
                return Users.IndexOf(new User { Email = email });
            }
            else
            {
                return -1;
            }
        }
    }
    public class User
    {
        private string _name;
        public string Name { get => _name; set => _name = value; }
        private string _email;
        public string Email { get => _email; set => _email = value; }
        private string _password;
        public string Password { get => _password; set => _password = value; }

    }
}
