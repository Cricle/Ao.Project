using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ao.Project.Test
{
    [TestClass]
    public class ProjectTest
    {
        [TestMethod]
        public void Init_AllMustNotNull()
        {
            var project = new Project();
            Assert.IsNotNull(project.Metadatas);
            Assert.IsNotNull(project.Features);

            Assert.IsNotNull(project.ItemGroups);
            Assert.IsNotNull(project.PropertyGroups);

            IProjectSkeleton skeleton = project;

            for (int i = 0; i < skeleton.ItemGroup.Items.Count; i++)
            {
                Assert.AreEqual(skeleton.ItemGroup.Items[i], project.ItemGroups[i]);
            }
            for (int i = 0; i < skeleton.PropertyGroup.Items.Count; i++)
            {
                Assert.AreEqual(skeleton.PropertyGroup.Items[i], project.PropertyGroups[i]);
            }
        }
        [TestMethod]
        public void CreateWithSkeleton()
        {
            var sk = new ProjectSkeleton
            {
                
                PropertyGroup = new PropertyGroup(new List<IPropertyGroupItem>
                 {
                     new DelegatePropertyGroupItem(null),
                     new DelegatePropertyGroupItem(null),
                 }),
                ItemGroup = new ItemGroup(new List<IItemGroupPart>
                  {
                      new DelegateItemGroupPart(null),
                      new DelegateItemGroupPart(null),
                  })
            };
            var proj = new Project(sk);

            Assert.AreEqual(sk.PropertyGroup.Items[0], proj.PropertyGroups[0]);
            Assert.AreEqual(sk.PropertyGroup.Items[1], proj.PropertyGroups[1]);

            Assert.AreEqual(sk.ItemGroup.Items[0], proj.ItemGroups[0]);
            Assert.AreEqual(sk.ItemGroup.Items[1], proj.ItemGroups[1]);
        }
        [TestMethod]
        public void Reset()
        {
            var proj = new Project
            {
                Features =
                {
                    ["a"]=1
                },
                Metadatas =
                {
                    ["b"]=2
                }
            };
            proj.Reset();
            Assert.AreEqual(0, proj.Features.Count);
            Assert.AreEqual(0, proj.Metadatas.Count);
        }
        [TestMethod]
        public void GivenNullInit_MustThrowException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Project(null));
            Assert.ThrowsException<ArgumentNullException>(() => new Project().Add(null));
        }
        [TestMethod]
        public void AddToProject()
        {
            var proj = new Project
            {
                Features =
                {
                    ["a"]=1
                },
                Metadatas =
                {
                    ["b"]=2
                },
                PropertyGroups =
                {
                    new DelegatePropertyGroupItem(null),
                    new DelegatePropertyGroupItem(null),
                },
                ItemGroups =
                {
                    new DelegateItemGroupPart(null),
                    new DelegateItemGroupPart(null),
                },
            };
            var next = new Project();

            next.Add(proj);
            Assert.AreEqual(1, next.Features["a"]);
            Assert.AreEqual(2, next.Metadatas["b"]);

            Assert.AreEqual(proj.PropertyGroups[0], next.PropertyGroups[0]);
            Assert.AreEqual(proj.PropertyGroups[1], next.PropertyGroups[1]);

            Assert.AreEqual(proj.ItemGroups[0], next.ItemGroups[0]);
            Assert.AreEqual(proj.ItemGroups[1], next.ItemGroups[1]);
        }
        [TestMethod]
        public async Task RunSome()
        {
            var i = 0;
            var project = new Project();

            project.PropertyGroups.Add(new DelegatePropertyGroupItem(() => i += 1));
            project.ItemGroups.Add(new DelegateItemGroupPart(() => i += 10)
            {
                DisposeAction = () => i -= 5
            });

            project.Decorate();
            await project.ConductAsync();
            project.Dispose();

            Assert.AreEqual(6, i);
        }
    }
}
