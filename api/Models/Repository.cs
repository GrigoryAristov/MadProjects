using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Repository
    {
        public int Id { get; set; }
        public Project? ProjectFkey { get; set; }
        public string URL { get; set; } = string.Empty;
    }
}