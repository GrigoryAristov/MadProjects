using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Status
    {
        public int Id { get; set; }
        public int SprintFkey { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}