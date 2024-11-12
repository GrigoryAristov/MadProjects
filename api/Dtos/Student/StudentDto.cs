using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Student
{
    public class StudentDto
    {
        public string GitHub { get; set; } = string.Empty;
        public int? StudentGroupId { get; set; }
        public string? UserId { get; set; }
    }
}