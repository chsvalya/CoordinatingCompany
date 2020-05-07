using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }

        public Teacher() {

        }

        public Teacher(int id, string name, string phone, string email, Department department)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Department = department;
        }
    }
}
