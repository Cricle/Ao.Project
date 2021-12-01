using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace Ao.Project
{
    public interface IProject : IItemGroupPart, IPropertyGroupItem
    {
        ConcurrentDictionary<string, object> Features { get; }
        ConcurrentDictionary<string, object> Metadatas { get; }

        ObservableCollection<IItemGroupPart> ItemGroups { get; }
        ObservableCollection<IPropertyGroupItem> PropertyGroups { get; }
    }
}