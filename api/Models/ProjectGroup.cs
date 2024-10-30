using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProjectGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Professor? ProfessorFkey { get; set; }
        public List<ProjectGroupProject> ProjectGroupProjects { get; set ;} = new List<ProjectGroupProject>();
    }
}