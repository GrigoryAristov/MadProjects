using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public DegreeCode? DegreeCodeFkey { get; set; }
        public User? IdFkey { get; set; }
        public List<ProjectGroup> ProjectGroups { get; set; } = new List<ProjectGroup>();
    }
}