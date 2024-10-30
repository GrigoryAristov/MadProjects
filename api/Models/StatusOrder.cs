using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StatusOrder
    {
        public int Id { get; set; }
        public Status? StatusFkey { get; set; }
        public Sprint? SprintFkey { get; set; }
        public int Order { get; set; }
    }
}