using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{
    public enum Type
    {
        Olympiads,
        Exams,
        SchoolProgram
    }
    public class Course
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public Department Department { get; set; }
        public List<Request> Requests { get; set; }
    }
}
