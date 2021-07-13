using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Project.Core.Adapters.Implement;
using Project.Core.Entities.Project;

namespace Project.Core.Tests.Adapters
{
    [TestFixture]
    class ProjectAdapterTests
    {
        [Test]
        public void GetAllTest()
        {
            var adapter = new ProjectAdapter();
            var result = adapter.GetAll();

            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetTest()
        {
            var adapter = new ProjectAdapter();
            var result = adapter.Get(Guid.Parse("EDFF51C5-51C5-44C2-887C-09A433B586A7"));

            Assert.NotNull(result);
        }

        [Test]
        public void InsertTest()
        {
            var model = new ProjectModel() { ProjectId = Guid.NewGuid(), ProjectName = "insert test" };
            
            var adapter = new ProjectAdapter();
            var result = adapter.Insert(model);

            Assert.IsTrue(result);
        }

        [Test]
        public void UpdateTest()
        {
            var model = new ProjectModel() { ProjectId = Guid.Parse("0C3972A5-7907-4BC3-BA5B-673A5995CBDB"), ProjectName = "update test" };
            
            var adapter = new ProjectAdapter();
            var result = adapter.Update(model);

            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteTest()
        {
            var adapter = new ProjectAdapter();
            var result = adapter.Delete(Guid.Parse("0C3972A5-7907-4BC3-BA5B-673A5995CBDB"));

            Assert.IsTrue(result);
        }
    }
}
