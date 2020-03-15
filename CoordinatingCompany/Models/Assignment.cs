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
        public Status Status { get; set; }
        public int TeacherId { get; set; }
        public int RequestId { get; set; }

        public Assignment(Status status, int teacherId, int requestId)
        {
            Status = status;
            TeacherId = teacherId;
            RequestId = requestId;
        }

    }
}
