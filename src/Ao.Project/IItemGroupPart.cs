using System;
using System.Threading.Tasks;

namespace Ao.Project
{
    public interface IItemGroupPart : IProjectPart, IDisposable
    {
        Task ConductAsync(IProject project);
    }
}
