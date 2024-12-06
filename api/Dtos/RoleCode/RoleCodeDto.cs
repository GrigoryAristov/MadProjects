using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.RoleCode
{
    public class RoleCodeDto
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public string? UserId { get; set; }
    }
}