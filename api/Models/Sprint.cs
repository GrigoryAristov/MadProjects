using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime DateEnd { get; set; } = DateTime.Now;
        public DateTime DateExpect { get; set; } = DateTime.Now;
        public int ProjectFkey { get; set; }
        public int UserFkey { get; set; }
        public int Order { get; set; }
    }
}