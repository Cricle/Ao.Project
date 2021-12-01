using System.Collections.Generic;

namespace Ao.Project
{
    public class ProjectSkeleton : IProjectSkeleton
    {
        public IList<IPropertyGroupItem> PropertyGroups { get; set; }

        public IList<IItemGroupPart> ItemGroups { get; set; }
    }
}
