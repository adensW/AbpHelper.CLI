using System;
using System.Linq;

namespace EasyAbp.AbpHelper.Core.Models
{
    public class ProjectInfo
    {
        public ProjectInfo(string baseDirectory, string fullName, TemplateType templateType, UiFramework uiFramework,
            bool tiered, string? name = null,string? subname=null)
        {
            BaseDirectory = baseDirectory;
            TemplateType = templateType;
            UiFramework = uiFramework;
            Tiered = tiered;
            FullName = fullName;
            Subname = subname??"";
            Name = name ?? FullName.Split('.').Last();
            ProjectFullName = FullName + (subname != null ? "." + subname : "");
        }

        public string BaseDirectory { get; }
        public string FullName { get; }
        public string ProjectFullName { get; }
        public string Name { get; }
        public string Subname { get; }
        public TemplateType TemplateType { get; }
        public UiFramework UiFramework { get; }
        public bool Tiered { get; }

        public override string ToString()
        {
            return
                $"{nameof(BaseDirectory)}: {BaseDirectory}, {nameof(FullName)}: {FullName}, {nameof(Name)}: {Name}, {nameof(TemplateType)}: {TemplateType}, {nameof(UiFramework)}: {UiFramework}, {nameof(Tiered)}: {Tiered}";
        }
    }

    public enum TemplateType
    {
        Application,
        Module
    }

    public enum UiFramework
    {
        None,
        RazorPages,
        Angular
    }
}