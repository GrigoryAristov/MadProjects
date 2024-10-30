using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class SprintCard
    {
        public int Id { get; set; }
        public Sprint? SprintFkey { get; set; }
        public Card? CardFkey { get; set; }
    }
}