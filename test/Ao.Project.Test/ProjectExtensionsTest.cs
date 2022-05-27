using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ao.Project.Test
{
    [TestClass]
    public class ProjectExtensionsTest
    {
        [TestMethod]
        public void GivenNullCall_MustThrowException()
        {
            var project = new Project();

            Assert.ThrowsException<ArgumentNullException>(() => ProjectExtensions.FindItemGroupParts(null, typeof(object)).Count());
            Assert.ThrowsException<ArgumentNullException>(() => ProjectExtensions.FindItemGroupParts<DelegateItemGroupPart>(null).Count());
            Assert.ThrowsException<ArgumentNullException>(() => ProjectExtensions.FindItemGroupParts(null, a => true).Count());
            Assert.ThrowsException<ArgumentNullException>(() => ProjectExtensions.FindItemGroupParts(project, (Predicate<IItemGroupPart>)null).Count());
        }
        [TestMethod]
        public void FindItemGroup()
        {
            var proj = new Project();
            for (int i = 0; i < 10; i++)
            {
                proj.ItemGroups.Add(new DelegateItemGroupPart(null));
            }
            var val = ProjectExtensions.FindItemGroupParts<DelegateItemGroupPart>(proj);
            Assert.AreEqual(10,val.Count());

        }
    }
}
