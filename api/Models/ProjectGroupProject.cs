using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProjectGroupProject
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? ProjectId { get; set; }
        public ProjectGroup? GroupFkey { get; set; }
        public Project? ProjectFkey { get; set; }
    }
}