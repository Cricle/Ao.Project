using System.IO;

namespace Ao.Project
{
    public interface IProjectInterop
    {
        void Load(IProject project, Stream stream);
        void Load(IProject project, string str);

        string Save(IProjectSkeleton project);

        void Save(IProjectSkeleton project, Stream stream);
    }
}
