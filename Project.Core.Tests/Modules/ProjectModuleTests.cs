using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Project.Core.Adapters;
using Project.Core.Entities.Project;
using Project.Core.Module.Implement;

namespace Project.Core.Tests.Modules
{
    [TestFixture]
    class ProjectModuleTests
    {
        IProjectAdapter _projectAdapter = Substitute.For<IProjectAdapter>();

        [Test]
        public void GetTest()
        {
            _projectAdapter.Get().Returns(new List<ProjectModel>() { new ProjectModel() { ProjectId =Guid.NewGuid(), ProjectName = "Project1" } });

            var module = new ProjectModule(_projectAdapter);
            var result = module.Get();

            Assert.IsTrue(result.Count > 0);
        }
    }
}
