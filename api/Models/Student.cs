using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Student
    {
        public int IdFkey { get; set; }
        public string GitHub { get; set; } = string.Empty;
        public int GroupFkey { get; set; }
    }
}