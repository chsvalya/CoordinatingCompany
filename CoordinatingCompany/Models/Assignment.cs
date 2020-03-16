using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{ 
    public enum Status
    {
        Created,
        TeacherApprove,
        HeadOfDepartmentApprove,
        SchoolConfirm,
        Canceled
    }

    public class Assignment
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public Teacher Teacher { get; set; }
        public Request Request { get; set; }
    }
}
