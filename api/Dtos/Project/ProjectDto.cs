using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Repo;
using api.Models;

namespace api.Dtos.Project
{
    public class ProjectDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InviteCode { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public int NumParticipants { get; set; }
        public bool Approved { get; set; }
        public int Grade { get; set; }
        public List<RepoDto> Repositories { get; set; }
        public List<ProjectGroupProject> ProjectGroupProjects { get; set; } = new List<ProjectGroupProject>();
        public List<UserProject> UserProjects { get; set; } = new List<UserProject>();
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();
    }
}