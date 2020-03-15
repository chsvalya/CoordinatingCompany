using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{
    public enum Subject
    {
        Astronomy,
        Biology,
        Chemistry,
        Economics,
        History,
        Mathematics,
        Physics,
        Programming
    }
    public enum Type
    {
        ReadyToPassExams,
        ReadyToWinOlympiads,
        ReadyToLearnSomethingNew
    }
    public class Course
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public Subject Subject { get; set; }
        public int DepartmentId { get; set; }
        public List<Request> Requests { get; set; }

        public Course(int id, Type type, Subject subject, int depId)
        {
            Id = id;
            Type = type;
            Subject = subject;
            DepartmentId = depId;
            Requests = new List<Request>();
        }
    }
}
