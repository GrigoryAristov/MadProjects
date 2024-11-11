using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public int? DegreeCodeId { get; set; }
        public string? UserId { get; set; }
        public DegreeCode? DegreeCode { get; set; }
        public User? User { get; set; }
        public List<ProjectGroup> ProjectGroups { get; set; } = new List<ProjectGroup>();
    }
}