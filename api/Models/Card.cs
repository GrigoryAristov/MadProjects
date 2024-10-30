using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public Status? StatusFkey { get; set; }
        public User? UserFkey { get; set; }
        public List<SprintCard> SprintCards { get; set; } = new List<SprintCard>();
        public List<CardOrder> CardOrders { get; set; } = new List<CardOrder>();
    }
}