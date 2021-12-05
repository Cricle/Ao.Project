﻿using Newtonsoft.Json;
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
            if (sk.ItemGroup != null)
            {
                foreach (var group in sk.ItemGroup.Items)
                {
                    project.ItemGroups.Add(group);
                }
            }
            if (sk.PropertyGroup != null)
            {
                foreach (var prop in sk.PropertyGroup.Items)
                {
                    project.PropertyGroups.Add(prop);
                }
            }
        }

        public string Save(IProject project)
        {
            var sk = new ProjectSkeleton
            {
                ItemGroup = new ItemGroup(project.ItemGroups),
                PropertyGroup = new PropertyGroup(project.PropertyGroups)
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
