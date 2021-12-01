using System.Collections.Generic;

namespace Ao.Project
{
    public interface IProjectSkeleton
    {
        IList<IPropertyGroupItem> PropertyGroups { get; }

        IList<IItemGroupPart> ItemGroups { get; }
    }
}
