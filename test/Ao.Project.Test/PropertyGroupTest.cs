using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ao.Project.Test
{
    [TestClass]
    public class PropertyGroupTest
    {
        [TestMethod]
        public void Decorate_AllMustDecorated()
        {
            var i = 0;
            var group = new PropertyGroup();
            group.Items.Add(new DelegatePropertyGroupItem(() => i += 1));
            group.Items.Add(new DelegatePropertyGroupItem(() => i += 2));
            group.Items.Add(new DelegatePropertyGroupItem(() => i += 3));
            group.Items.Add(new DelegatePropertyGroupItem(() => i += 4));

            group.Decorate(null);

            Assert.AreEqual(10, i);
        }
        [TestMethod]
        public void ListMethods()
        {
            var group = new PropertyGroup();

            var del = new DelegatePropertyGroupItem(null);

            group.Add(del);
            Assert.AreEqual(1, group.Items.Count);
            Assert.AreEqual(group.Items.Count, group.Count);

            Assert.IsTrue(group.Contains(del));

            var del2 = new DelegatePropertyGroupItem(null);
            group.Insert(1, del2);
            Assert.AreEqual(2,group.Count);

            Assert.AreEqual(del2,group[1]);
            group.RemoveAt(1);
            Assert.AreEqual(1,group.Count);
            group.Add(del2);
            Assert.AreEqual(1, group.IndexOf(del2));

            Assert.IsTrue(group.Remove(del2));

            group.Clear();
            Assert.AreEqual(0, group.Count);
        }
    }
}
