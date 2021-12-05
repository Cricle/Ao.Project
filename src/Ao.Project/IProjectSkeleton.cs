using System.Collections.Generic;

namespace Ao.Project
{
    public interface IProjectSkeleton
    {
        PropertyGroup PropertyGroup { get; }

        ItemGroup ItemGroup { get; }
    }
}
