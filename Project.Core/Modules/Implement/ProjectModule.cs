using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Entities.Project;

namespace Project.Core.Module.Implement
{
    public class ProjectModule : IProjectModule
    {
        public List<ProjectModel> Get()
        {
            return new List<ProjectModel>() { new ProjectModel() { ProjectName = "aadsd" } };
        }
    }
}
