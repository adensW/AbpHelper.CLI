﻿using System.Linq;
using Humanizer;

namespace EasyAbp.AbpHelper.Models
{
    public class ServiceInfo
    {
        public string Namespace { get; }
        public string NamespaceLastPart => Namespace.Split('.').Last();
        public string Name { get; }
        public string NamePluralized => Name.Pluralize();

        public ServiceInfo(string @namespace, string name)
        {
            Namespace = @namespace;
            Name = name;
        }
    }
}