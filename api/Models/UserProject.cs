using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserProject
    {
        public int Id { get; set; }
        public User? UserFkey { get; set; }
        public Project? ProjectFkey { get; set; }
        public ProjectRoleCode? ProjectRoleCodeFkey { get; set; }
    }
}