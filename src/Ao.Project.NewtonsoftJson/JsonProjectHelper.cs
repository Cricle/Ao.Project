using Newtonsoft.Json;
using System.IO;

namespace Ao.Project.NewtonsoftJson
{
    public class JsonProjectInterop : IProjectInterop
    {
        private static readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public static readonly JsonProjectInterop Instance = new JsonProjectInterop();

        private JsonProjectInterop() { }

        public void Load(IProject project, Stream stream)
        {
            var sr = new StreamReader(stream);
            Load(project, sr.ReadToEnd());
        }

        public void Load(IProject project, string str)
        {
            var sk = JsonConvert.DeserializeObject<ProjectSkeleton>(str, settings);
            if (sk.ItemGroups != null)
            {
                foreach (var group in sk.ItemGroups)
                {
                    project.ItemGroups.Add(group);
                }
            }
            if (sk.PropertyGroups != null)
            {
                foreach (var prop in sk.PropertyGroups)
                {
                    project.PropertyGroups.Add(prop);
                }
            }
        }

        public string Save(IProject project)
        {
            var sk = new ProjectSkeleton
            {
                ItemGroups = project.ItemGroups,
                PropertyGroups = project.PropertyGroups
            };
            return JsonConvert.SerializeObject(sk, settings);
        }

        public void Save(IProject project, Stream stream)
        {
            var sw = new StreamWriter(stream);
            var str = Save(project);
            sw.Write(str);
        }
    }
}
