using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Proffessor
{
    public class ProffessorDto
    {
        public int? DegreeCodeId { get; set; }
        public string? UserId { get; set; }
        public List<ProjectGroup> ProjectGroups { get; set; }
    }
}