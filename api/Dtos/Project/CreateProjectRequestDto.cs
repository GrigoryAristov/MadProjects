using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Project
{
    public class CreateProjectRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string InviteCode { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
        public int NumParticipants { get; set; }
        public bool Approved { get; set; }
        public int Grade { get; set; }
    }
}