using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.WebApi.Models
{
    public class ProjectViewModel
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}