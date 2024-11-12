using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Student;
using api.Models;

namespace api.Dtos.Group
{
    public class GroupDto
    {
        public string Number { get; set; } = string.Empty;
        public List<StudentDto> Students { get; set; }
    }
}