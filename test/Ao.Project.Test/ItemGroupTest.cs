using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ao.Project.Test
{
    [TestClass]
    public class ItemGroupTest
    {
        [TestMethod]
        public async Task Conduct_MustAllConduct()
        {
            var i = 0;
            var group = new ItemGroup();
            group.Items.Add(new DelegateItemGroupPart(() => i += 1));
            group.Items.Add(new DelegateItemGroupPart(() => i += 2));
            group.Items.Add(new DelegateItemGroupPart(() => i += 3));
            group.Items.Add(new DelegateItemGroupPart(() => i += 4));
            await group.ConductAsync(null);

            Assert.AreEqual(10, i);
        }
        [TestMethod]
        public void Dispose()
        {
            var i = 0;
            var group = new ItemGroup();
            group.Items.Add(new DelegateItemGroupPart(DelegateItemGroupPart.Empty) { DisposeAction = () => i += 1 });
            group.Items.Add(new DelegateItemGroupPart(DelegateItemGroupPart.Empty) { DisposeAction = () => i += 2 });
            group.Items.Add(new DelegateItemGroupPart(DelegateItemGroupPart.Empty) { DisposeAction = () => i += 3 });
            group.Items.Add(new DelegateItemGroupPart(DelegateItemGroupPart.Empty) { DisposeAction = () => i += 4 });
            group.Dispose();
            Assert.AreEqual(10, i);
        }
    }
}
