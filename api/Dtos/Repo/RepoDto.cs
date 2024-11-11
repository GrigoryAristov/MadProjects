using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Dtos.Repo
{
    public class RepoDto
    {
        public string URL { get; set; } = string.Empty;
        public int? ProjectId { get; set;}
    }
}