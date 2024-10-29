using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class UserProject
    {
        public int UserFkey { get; set; }
        public int ProjectFkey { get; set; }
        public int ProjectRoleCodeFkey { get; set; }
    }
}