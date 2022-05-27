using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Ao.Project
{
    public interface IProject : IItemGroupPart, IPropertyGroupItem
    {
        Task ConductAsync();
        void Decorate();

        ObservableCollection<IItemGroupPart> ItemGroups { get; }
        ObservableCollection<IPropertyGroupItem> PropertyGroups { get; }
    }
}