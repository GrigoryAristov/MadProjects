using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ProjectGroupProject
    {
        public int GroupFkey { get; set; }
        public int ProjectFkey { get; set; }
    }
}