using EasyAbp.AbpHelper.Core.Commands.Generate.Crud;
using EasyAbp.AbpHelper.Core.Commands.Generate.Service;
using System;
using System.Collections.Generic;
using System.CommandLine.Parsing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EasyApp.AbpHelper.Tests.Commands.Generate.Crud;
public class ServiceCommand_Tests: CommandTestsBase
{
  
    [Fact]
    public async Task Should_Service_Correct()
    {   
        var _crudCommand=GetRequiredService<ServiceCommand>();
        await _crudCommand.RunCommand(new ServiceCommandOption
        {
            Name="Bookmark",
            Directory= @"C:\Users\wangdingchen\Repos\Adens\Woo\Ego\modules\navigator",
            Folder= "Bookmarks",
            ProjectName="Navigator",
            Subname ="Public"
        });
    }
}
