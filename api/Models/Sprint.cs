using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateStart { get; set; } = DateTime.Now;
        public DateTime DateEnd { get; set; } = DateTime.Now;
        public DateTime DateExpect { get; set; } = DateTime.Now;
        public int Order { get; set; }
        public Project? ProjectFkey { get; set; }
        public User? UserFkey { get; set; }
        public List<StatusOrder> StatusOrders { get; set; } = new List<StatusOrder>();
        public List<Status> Statuses { get; set; } = new List<Status>();
        public List<SprintCard> SprintCards { get; set; } = new List<SprintCard>();
        public List<CardOrder> CardOrders { get; set; } = new List<CardOrder>();
    }
}