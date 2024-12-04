using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StudentGroup
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public List<Student> Students { get; set; } = new List<Student>();
    }
}