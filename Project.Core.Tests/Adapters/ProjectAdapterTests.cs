using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Project.Core.Adapters.Implement;

namespace Project.Core.Tests.Adapters
{
    [TestFixture]
    class ProjectAdapterTests
    {
        [Test]
        public void GetTest()
        {
            var adapter = new ProjectAdapter();
            var result = adapter.Get();

            Assert.IsTrue(result.Count > 0);
        }
    }
}
