using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Head { get; set; }

        public Department(int id, string name, string head)
        {
            Id = id;
            Name = name;
            Head = head;
        }
    }
}
