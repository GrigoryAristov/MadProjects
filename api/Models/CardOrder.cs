using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CardOrder
    {
        public int Id { get; set; }
        public Card? CardFkey { get; set; }
        public Sprint? SprintFkey { get; set; }
        public string Order { get; set; } = string.Empty;
    }
}