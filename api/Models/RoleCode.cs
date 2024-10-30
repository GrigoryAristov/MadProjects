using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class RoleCode
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public List<User> Users { get; set; } = new List<User>();
    }
}