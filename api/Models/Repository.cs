using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Repo
    {
        public int Id { get; set; }
        public string URL { get; set; } = string.Empty;
        public int? ProjectId { get; set;}
        public Project? Project { get; set; }
    }
}