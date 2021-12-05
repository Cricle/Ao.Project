using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Ao.Project
{
    public class Project : ProjectPart, IItemGroupPart, IPropertyGroupItem, IProject, IProjectSkeleton
    {
        public ConcurrentDictionary<string, object> Features { get; }
        public ConcurrentDictionary<string, object> Metadatas { get; }
        public ObservableCollection<IPropertyGroupItem> PropertyGroups { get; }
        public ObservableCollection<IItemGroupPart> ItemGroups { get; }

        PropertyGroup IProjectSkeleton.PropertyGroup => new PropertyGroup(PropertyGroups);

        ItemGroup IProjectSkeleton.ItemGroup => new ItemGroup(ItemGroups);

        public Project()
        {
            Features = new ConcurrentDictionary<string, object>();
            Metadatas = new ConcurrentDictionary<string, object>();
            PropertyGroups = new ObservableCollection<IPropertyGroupItem>();
            ItemGroups = new ObservableCollection<IItemGroupPart>();
        }
        public Project(IProjectSkeleton skeleton)
        {
            if (skeleton is null)
            {
                throw new ArgumentNullException(nameof(skeleton));
            }

            Features = new ConcurrentDictionary<string, object>();
            Metadatas = new ConcurrentDictionary<string, object>();
            if (skeleton.PropertyGroup==null)
            {
                PropertyGroups = new ObservableCollection<IPropertyGroupItem>();
            }
            else
            {
                PropertyGroups = new ObservableCollection<IPropertyGroupItem>(skeleton.PropertyGroup.Items);
            }
            if (skeleton.ItemGroup == null)
            {
                ItemGroups = new ObservableCollection<IItemGroupPart>();
            }
            else
            {
                ItemGroups = new ObservableCollection<IItemGroupPart>(skeleton.ItemGroup.Items);
            }
        }


        public void Add(IProject project)
        {
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            foreach (var item in project.Features)
            {
                Features[item.Key] = item.Value;
            }
            foreach (var item in project.Metadatas)
            {
                Metadatas[item.Key] = item.Value;
            }
            foreach (var item in project.PropertyGroups)
            {
                PropertyGroups.Add(item);
            }
            foreach (var item in project.ItemGroups)
            {
                ItemGroups.Add(item);
            }
        }

        public override void Reset()
        {
            Features.Clear();
            Metadatas.Clear();
        }
        public void Decorate()
        {
            Decorate(this);
        }
        public void Decorate(IProject project)
        {
            foreach (var group in PropertyGroups)
            {
                group.Decorate(project);
            }
        }
        public Task ConductAsync()
        {
            return ConductAsync(this);
        }
        public async Task ConductAsync(IProject project)
        {
            foreach (var group in ItemGroups)
            {
                await group.ConductAsync(project);
            }
        }

        public void Dispose()
        {
            foreach (var item in ItemGroups)
            {
                item.Dispose();
            }
            ItemGroups.Clear();
            Features.Clear();
            Metadatas.Clear();
            PropertyGroups.Clear();
        }
    }
}
