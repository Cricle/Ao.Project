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
    }
}
