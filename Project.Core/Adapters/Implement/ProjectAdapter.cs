using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Entities.Project;

namespace Project.Core.Adapters.Implement
{
    public class ProjectAdapter : IProjectAdapter
    {
        public List<ProjectModel> Get()
        {
            return new List<ProjectModel>() { new ProjectModel() { ProjectName = "Project1" } };
        }
    }
}
