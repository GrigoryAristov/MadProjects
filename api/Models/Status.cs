using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace api.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Sprint? SprintFkey { get; set; }
        public List<Card> Cards { get; set; } = new List<Card>();
        public List<StatusOrder> StatusOrders { get; set; } = new List<StatusOrder>();
    }
}