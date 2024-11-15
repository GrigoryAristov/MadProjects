using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User:IdentityUser
    {
        public List<Professor> Professors { get; set; } = new List<Professor>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<UserProject> UserProjects { get; set; } = new List<UserProject>();
        public List<Sprint> Sprints { get; set; } = new List<Sprint>();
        public List<Card> Cards { get; set; } = new List<Card>();
        public int? RoleCodeId { get; set; }
        public RoleCode? RoleCodeFkey { get; set; }
    }
}