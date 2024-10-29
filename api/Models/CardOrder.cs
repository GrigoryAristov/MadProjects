using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CardOrder
    {
        public int CardFkey { get; set; }
        public int SprintFkey { get; set; }
        public string Order { get; set; } = string.Empty;
    }
}