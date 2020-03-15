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
        public int Age { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }

        public Teacher(int id, string name, int age, string phone, int depId)
        {
            Id = id;
            Name = name;
            Age = age;
            Phone = phone;
            DepartmentId = depId;
        }
    }
}
