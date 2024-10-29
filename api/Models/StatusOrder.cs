using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class StatusOrder
    {
        public int StatusFkey { get; set; }
        public int SprintFkey { get; set; }
        public int Order { get; set; }
    }
}