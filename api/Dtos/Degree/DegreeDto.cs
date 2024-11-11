using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos
{
    public class DegreeDto
    {
        public string Degree { get; set; } = string.Empty;
        public List<Professor> Professors { get; set; }
    }
}