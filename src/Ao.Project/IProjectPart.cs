using System;

namespace Ao.Project
{
    public interface IProjectPart : IDisposable
    {
        void Reset();

        void Initialize(IServiceProvider provider);
    }
}
