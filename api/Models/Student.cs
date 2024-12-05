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
        // public List<StudentGroup> StudentGroups { get; set; } = new List<StudentGroup>();
        // public int? StudentGroupId { get; set; }
        public string? UserId { get; set; }
        public int? StudentGroupId { get; set; }
        public StudentGroup? StudentGroup { get; set; }
        public User? User { get; set; }
    }
}