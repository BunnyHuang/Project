using System;
using System.ComponentModel.DataAnnotations;

namespace Project.WebApi.Models
{
    public class ProjectViewModel
    {
        [Required]
        public Guid ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
    }
}