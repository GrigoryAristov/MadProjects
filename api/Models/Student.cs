using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string GitHub { get; set; } = string.Empty;
        public Group? GroupFkey { get; set; }
        public User? IdFkey { get; set; }
    }
}