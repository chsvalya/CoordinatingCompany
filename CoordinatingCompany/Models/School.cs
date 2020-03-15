using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoordinatingCompany.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public List<Request> Requests { get; set; }

        public School(int id, string address, string name)
        {
            Id = id;
            Address = address;
            Name = name;
            Requests = new List<Request>();
        }
    }
}
