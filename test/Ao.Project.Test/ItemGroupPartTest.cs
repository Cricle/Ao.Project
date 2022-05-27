using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ao.Project.Test
{
    [TestClass]
    public class ItemGroupPartTest
    {
        class NullItemGroupPart : ItemGroupPart
        {
            public override Task ConductAsync(IProject project)
            {
                return Task.FromResult(0);
            }
        }
        [TestMethod]
        public async Task Conduct_Dispose()
        {
            var part=new NullItemGroupPart();
            await part.ConductAsync(null);
            part.Dispose();
        } 
    }
}
