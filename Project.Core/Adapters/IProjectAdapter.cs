using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Entities.Project;

namespace Project.Core.Adapters
{
    public interface IProjectAdapter
    {
        List<ProjectModel> GetAll();
        ProjectModel Get(Guid projectId);
        List<ProjectDto> GetWithMember(Guid projectId);
        ProjectModel Get(string projectName);
        bool Insert(ProjectModel model);
        bool Update(ProjectModel model);
        bool Delete(Guid projectId);
    }
}
