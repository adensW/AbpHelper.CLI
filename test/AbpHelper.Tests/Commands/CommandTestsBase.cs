using System;
using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using Volo.Abp;
using CommandLineBuilder = EasyAbp.AbpHelper.Core.Commands.CommandLineBuilder;

namespace EasyApp.AbpHelper.Tests.Commands;
public class CommandTestsBase : AbpHelperTestBase
{
    
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
        
    }
    public Parser UsingParser()
    {

        var ServiceProvider = GetRequiredService<IServiceProvider>();
        var parser = new CommandLineBuilder(ServiceProvider, "abphelper")
                    .AddAllRootCommands()
                    .UseDefaults()
                    .Build();
        return parser;
    }
}
