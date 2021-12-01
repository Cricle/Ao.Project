using System.IO;

namespace Ao.Project
{
    public interface IProjectInterop
    {
        void Load(IProject project, Stream stream);
        void Load(IProject project, string str);

        string Save(IProject project);

        void Save(IProject project, Stream stream);
    }
}
