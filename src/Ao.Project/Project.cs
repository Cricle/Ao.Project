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
        public static readonly IPropertyGroupItem[] EmptyPropertyGroupItems = new PropertyGroupItem[0];
        public static readonly IItemGroupPart[] EmptyItemGroupPart = new IItemGroupPart[0];


        public ConcurrentDictionary<string, object> Features { get; }
        public ConcurrentDictionary<string, object> Metadatas { get; }
        public ObservableCollection<IPropertyGroupItem> PropertyGroups { get; }
        public ObservableCollection<IItemGroupPart> ItemGroups { get; }

        IList<IPropertyGroupItem> IProjectSkeleton.PropertyGroups => PropertyGroups;

        IList<IItemGroupPart> IProjectSkeleton.ItemGroups => ItemGroups;

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
            PropertyGroups = new ObservableCollection<IPropertyGroupItem>(skeleton.PropertyGroups?? EmptyPropertyGroupItems);
            ItemGroups = new ObservableCollection<IItemGroupPart>(skeleton.ItemGroups?? EmptyItemGroupPart);
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
            foreach (var group in PropertyGroups)
            {
                group.Decorate();
            }
        }
        public async Task ConductAsync()
        {
            foreach (var group in ItemGroups)
            {
                await group.ConductAsync();
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
