using CoordinatingCompany.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoordinatingCompany.Data
{
    public static class TeacherManager
    {
        private const string UsersFileName = "Data/Users.json";
        private static List<Teacher> teachers;
        private static Dictionary<string, string> users = GetUsers();
        private static List<Teacher> Teachers { get; set; }

        private static Dictionary<string, string> GetUsers()
        {
            try
            {
                using var sr = new StreamReader(UsersFileName);
                using var jr = new JsonTextReader(sr);
                var serializer = new JsonSerializer();
                users = serializer.Deserialize<Dictionary<string, string>>(jr);
            }
            catch
            {
                users = new Dictionary<string, string>();
            }
            return users;
        }

        private static List<Teacher> GetTeachers(CoordinatingCompanyContext context) 
            => context.Teachers.Include(t => t.Department).ToList();

        private static void SaveChanges(Dictionary<string, string> data)
        {
            using var sw = new StreamWriter(UsersFileName);
            using var jw = new JsonTextWriter(sw);
            var serializer = new JsonSerializer() { Formatting = Formatting.Indented };
            serializer.Serialize(jw, data);
        }


        private static string HashPassword(string password)
        {
            MD5 md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashBytes);
        }

        public static void ActivateTeacher(string email, string password, CoordinatingCompanyContext context)
        {
            Teachers = teachers ?? (teachers = GetTeachers(context));
            if (Teachers.Any(t => t.Email == email))
                users.Add(email, HashPassword(password));
            SaveChanges(users);
        }

        public static bool CheckTeacher(string email, string password) =>
           GetUsers().Any(u => u.Key == email && u.Value == HashPassword(password));
    }
}
