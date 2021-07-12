using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Entities.Project;

namespace Project.Core.Module
{
    public interface IProjectModule
    {
        List<ProjectModel> Get();
    }
}
