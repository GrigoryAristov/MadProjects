using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Repo
{
    public class CreateRepoDto
    {
        [Required]
        [MinLength(5)]
        public string URL { get; set; } = string.Empty;
        // public int? ProjectId { get; set;}
    }
}