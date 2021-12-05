using System;
using System.Threading.Tasks;

namespace Ao.Project.Sample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var proj = new Project();

            proj.ItemGroups.Add(new SayHelloTask());
            proj.Decorate();
            proj.ConductAsync().GetAwaiter().GetResult();
        }
    }
    class SayHelloTask : ItemGroupPart
    {
        public override Task ConductAsync(IProject project)
        {
            Console.WriteLine("Hello!");
            return Task.CompletedTask;
        }
    }
}
