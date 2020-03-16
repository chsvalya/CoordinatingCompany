using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{
    public class Request
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; } 
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int Form { get; set; }
        public Course Course { get; set; }
        public School School { get; set; }
    }
}
