using System.Collections.Generic;

namespace Ao.Project
{
    public class ProjectSkeleton : IProjectSkeleton
    {
        public PropertyGroup PropertyGroup { get; set; }

        public ItemGroup ItemGroup { get; set; }
    }
}
