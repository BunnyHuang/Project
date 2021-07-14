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
        public void GetAllTest()
        {
            _projectAdapter.GetAll().Returns(new List<ProjectModel>() { new ProjectModel() { ProjectId =Guid.NewGuid(), ProjectName = "Project1" } });

            var module = new ProjectModule(_projectAdapter);
            var result = module.GetAll();

            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetTest()
        {
            _projectAdapter.Get(Arg.Any<Guid>()).Returns(new ProjectModel() { ProjectId = Guid.NewGuid(), ProjectName = "Project1" });

            var module = new ProjectModule(_projectAdapter);
            var result = module.Get(Guid.NewGuid());

            Assert.NotNull(result);
        }

        [Test]
        public void InsertTest_ProjectName_Is_Exist()
        {
            _projectAdapter.Get(Arg.Any<string>()).Returns(new ProjectModel());
            _projectAdapter.Insert(Arg.Any<ProjectModel>()).Returns(true);

            var module = new ProjectModule(_projectAdapter);
            var result = module.Insert("insert test");

            Assert.IsFalse(result);
        }

        [Test]
        public void InsertTest_ProjectName_Is_Not_Exist()
        {
            _projectAdapter.Get(Arg.Any<string>()).Returns(x => null);
            _projectAdapter.Insert(Arg.Any<ProjectModel>()).Returns(true);

            var module = new ProjectModule(_projectAdapter);
            var result = module.Insert("insert test");

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateTest_ProjectId_Is_Exist()
        {
            var model = new ProjectModel() { ProjectId = Guid.NewGuid(), ProjectName = "update test" };

            _projectAdapter.Get(Arg.Any<Guid>()).Returns(new ProjectModel());
            _projectAdapter.Update(Arg.Any<ProjectModel>()).Returns(true);

            var module = new ProjectModule(_projectAdapter);
            var result = module.Update(model);

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateTest_ProjectId_Is_Not_Exist()
        {
            var model = new ProjectModel() { ProjectId = Guid.NewGuid(), ProjectName = "update test" };

            _projectAdapter.Get(Arg.Any<Guid>()).Returns(x => null);
            _projectAdapter.Update(Arg.Any<ProjectModel>()).Returns(true);

            var module = new ProjectModule(_projectAdapter);
            var result = module.Update(model);

            Assert.IsFalse(result);
        }

        [Test]
        public void DeleteTest_ProjectId_Is_Exist()
        {
            _projectAdapter.GetWithMember(Arg.Any<Guid>()).Returns(new List<ProjectDto>());
            _projectAdapter.Delete(Arg.Any<Guid>()).Returns(true);

            var module = new ProjectModule(_projectAdapter);
            var result = module.Delete(Guid.NewGuid());

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteTest_ProjectId_Is_Not_Exist()
        {
            _projectAdapter.GetWithMember(Arg.Any<Guid>()).Returns(x => null);
            _projectAdapter.Delete(Arg.Any<Guid>()).Returns(true);

            var module = new ProjectModule(_projectAdapter);
            var result = module.Delete(Guid.NewGuid());

            Assert.IsFalse(result);
        }
    }
}
