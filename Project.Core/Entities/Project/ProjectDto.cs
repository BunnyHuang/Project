using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities.Project
{
    public class ProjectDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string MemberName { get; set; }
    }
}
